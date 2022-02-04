using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Ganss.XSS;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Processo
{
    public class DetailsModel : PageModel
    {
        private readonly INotyfService notyf;
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment ihostingEnvironment;

        public DetailsModel(INotyfService notyf, WeblawyersBox.Data.ApplicationDbContext context, IWebHostEnvironment ihostingEnvironment, UserManager<ApplicationUser> userManager)
        {
            this.notyf = notyf;
            _context = context;
            this.ihostingEnvironment = ihostingEnvironment;
            UserManager = userManager;
        }
        public PartialViewResult OnGetAlterarStatos()
        {
          
            // this handler returns _ContactModalPartial
            return new PartialViewResult
            {
                
                ViewName = "_AlterarStatos",
                ViewData = new ViewDataDictionary<EstatusProcess>(ViewData, new EstatusProcess { })
            };
        }
        private readonly static List<EstatusProcess> estatusProcess = new List<EstatusProcess>();
        // "save" os dados dos estatus
        public PartialViewResult OnPostSalvarStatos(EstatusProcess model)
        {
            if (ModelState.IsValid)
            {
             _context.EstatusProcesses.Add(model);
            }
            return new PartialViewResult
            {
                ViewName = "_AlterarStatos",
                ViewData = new ViewDataDictionary<EstatusProcess>(ViewData, new EstatusProcess { })
            };
        }
        public Processo_tb Processo_tb { get; set; }
        public estadoss Estadoss { get; set; }
        public List<TpProcesso> TpProcesso { get; set; }
        public List<Documentos_Processos_tb> documentos_Processos { get; set; }
        public List<Pessoas_Envolvidas_tb> pessoas_Envolvidas { get; set; }
        public List<Audiencia_tab> Audiencia_tab { get; set; }
        public List<Intrevistas> DetalhesdeActivida { get; set; }
        public List<ActividadesProcessos> actividadesProcessos { get; set; }
        public Cliente_tb cliente { get; set; }
        public IList<FacturacaoTbs> FacturacaoTbs { get; set; }
        public IList<FacturacaoTbs> despesad { get; set; }
        public IList<timesheetTbs> timesheetTbs { get; set; }
        public HtmlSanitizer sanitizer { get; set; } = new HtmlSanitizer();


        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return RedirectToPage("/erro/Erro404");

            }
            if (isguid(id))
            {
                try
                {

                    Processo_tb = await _context.Processo_Tbs.Include(v => v.Cliente_Tb).FirstOrDefaultAsync(m => m.Ids == id);
                    if (Processo_tb == null)
                    {
                        return RedirectToPage("/erro/Erro404");

                    }
                    documentos_Processos = await _context.Documentos_Processos_Tbs.Where(v => v.idProcesso == id).AsNoTracking().ToListAsync();
                    pessoas_Envolvidas = await _context.Pessoas_Envolvidas_Tbs.Where(v => v.idProcesso == id).AsNoTracking().ToListAsync();
                    actividadesProcessos = await _context.ActividadesProcessos.Where(v => v.idprocesso == id).AsNoTracking().ToListAsync();
                    cliente = await _context.Cliente_Tbs.Where(f => f.Ids == Processo_tb.Idcliente).FirstOrDefaultAsync();
                    Audiencia_tab = await _context.Audiencia_Tabs.Where(f => f.idProcesso == Processo_tb.Ids).AsNoTracking().ToListAsync();
                    FacturacaoTbs = await _context.FacturacaoTBs.Where(f => f.idprocesso == Processo_tb.Ids && f.tipofacturacao == tipofacturacao.Honorarios).ToListAsync();
                    despesad = await _context.FacturacaoTBs.Where(f => f.idprocesso == Processo_tb.Ids && f.tipofacturacao == tipofacturacao.Despesas).ToListAsync();
                    timesheetTbs = await _context.TimesheetTbs.Where(f => f.idprocesso == Processo_tb.Ids).AsNoTracking().ToListAsync();
                    DetalhesdeActivida = await _context.Intrevistas.Where(f => f.idprocesso == Processo_tb.Ids).AsNoTracking().ToListAsync();
                    ViewData["Idprocesso"] = id;
                    Estadoss = Processo_tb.Estados;
                }
                catch (Exception ex)
                {
                    
                    return RedirectToPage("/erro/Erro404");
                }



                ViewData["Ndocumotes"] = await _context.Documentos_Processos_Tbs.Where(v => v.idProcesso == id).CountAsync();
                ViewData["Npessoas"] = await _context.Pessoas_Envolvidas_Tbs.Where(v => v.idProcesso == id).CountAsync();
                ViewData["Neventos"] = await _context.Audiencia_Tabs.Where(v => v.idProcesso == id).CountAsync();
                ViewData["Nactifeito"] = await _context.ActividadesProcessos.Where(v => v.idprocesso == id && v.status == estado.Agendado).CountAsync();
                ViewData["nAtrazads"] = await _context.ActividadesProcessos.Where(v => v.idprocesso == id && v.status == estado.Agendado && v.data < DateTime.Now).CountAsync();
                ViewData["Notalhoras"] = await _context.TimesheetTbs.Where(v => v.idprocesso == id).SumAsync(d => d.horasrealizadas);
                ViewData["TotalHonorarios"] = await _context.FacturacaoTBs.Where(v => v.idprocesso == id && v.tipofacturacao == tipofacturacao.Honorarios).SumAsync(d => d.valor);
                ViewData["Totaldespesa"] = await _context.FacturacaoTBs.Where(v => v.idprocesso == id && v.tipofacturacao == tipofacturacao.Despesas).SumAsync(d => d.valor);
                var user = await UserManager.GetUserAsync(User);
                var em = _context.Empresa_Tbs.Where(b => b.Ids == user.idempresa).FirstOrDefault();
                string fullPath = Path.Combine(ihostingEnvironment.WebRootPath, "Escritorios/" + em.NomeEmpresa + "/");
                var totalsize = GetDirectorySize(fullPath);
                ViewData["TotalUsado"] = totalsize;
                // notyf.Warning("total espaco " + totalsize);

            }
            else
            {
                return RedirectToPage("/erro/Erro404");
            }
            return Page();
        }
        public Processo_tb Processo_Tb { get; set; }
        private static long GetDirectorySize(string folderPath)
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);
            var tota = di.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length);
            var megas = Math.Round((double)tota / (double)(1024 * 1024), 2);
            return (long)megas;
        }
       

        private bool Processo_tbExists(string id)
        {
            return _context.Processo_Tbs.Any(e => e.Ids == id&& e.Estados==estadoss.Activo);
        }
        public UserManager<ApplicationUser> UserManager { get; }
        public async void OnPostDelete(string id)
        {
            if (id == null)
            {
                notyf.Error("nenhum valor informado");
            }
            pessoas_Envolvidas_Tb = await _context.Pessoas_Envolvidas_Tbs.FindAsync(id);

            if (pessoas_Envolvidas_Tb != null)
            {
                _context.Pessoas_Envolvidas_Tbs.Remove(pessoas_Envolvidas_Tb);
                await _context.SaveChangesAsync();
                notyf.Success("Pessoa removida com sucesso");
            }

        }
        public async Task<FileResult> OnGetDownloadFile(string fileName,string idprocesso)
        {
            byte[] bytes = null;
            if (fileName != "")
            {
                var user = await UserManager.GetUserAsync(User);
                var em = _context.Empresa_Tbs.Where(b => b.Ids == user.idempresa).FirstOrDefault();
                //salvar na base de dadso

                //guardaor os arquivos
                Processo_Tb = _context.Processo_Tbs.Where(b => b.Ids == idprocesso).FirstOrDefault();
                var cli = _context.Cliente_Tbs.Where(c => c.Ids == Processo_Tb.Idcliente).FirstOrDefault();

                string fullPath = Path.Combine(ihostingEnvironment.WebRootPath, "Escritorios/" + em.NomeEmpresa + "/" + cli.Ids);
                //Build the File Path.
                string path = Path.Combine(fullPath, fileName);

               

                //Read the File data into Byte Array.
                 bytes = System.IO.File.ReadAllBytes(path);
            }
            else
            {
                notyf.Error("Comprovativo nao encontrado");
                return null;
            }
                    return File(bytes, "application/octet-stream", fileName);
        }
        public Pessoas_Envolvidas_tb pessoas_Envolvidas_Tb { get; set; }
        public async Task<FileResult> OnGetDeletsures(string idpessoa)
        {

            if (idpessoa == null)
            {
                notyf.Error("nenhum valor informado");
            }

            pessoas_Envolvidas_Tb = await _context.Pessoas_Envolvidas_Tbs.FindAsync(idpessoa);

            if (pessoas_Envolvidas_Tb != null)
            {
                _context.Pessoas_Envolvidas_Tbs.Remove(pessoas_Envolvidas_Tb);
                await _context.SaveChangesAsync();
                notyf.Success("Pessoa removida com sucesso");
            }
            return null;
        }
        static bool isguid(string codigo)
        {
            return Guid.TryParse(codigo, out Guid b);
        }
    }

}
