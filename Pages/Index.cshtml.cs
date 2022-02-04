using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ganss.XSS;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using WeblawyersBox.Data;
using WeblawyersBox.Models;
using WeblawyersBox.Pages.EmaiSservice;
using static WeblawyersBox.Email.EnviarEmailCliente;
using Message = WeblawyersBox.Pages.EmaiSservice.Message;

namespace WeblawyersBox.Pages
{[Authorize]
    public class IndexModel : PageModel
    {
        private readonly IEmailSenders _emailSender;
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment ihostingEnvironment;

        public string Message { get; set; }



        public IndexModel(IEmailSenders emailSender, ILogger<IndexModel> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment ihostingEnvironment)
        {
            this._emailSender = emailSender;
            _logger = logger;
            this.context = context;
            this.userManager = userManager;
            this.ihostingEnvironment = ihostingEnvironment;
        }
      
        public void OnPostFltrarEventos()
        {
            Message = $"View handler fired for {estatusdoevento}";
        }
        [BindProperty]
        public string logomarca { get; set; }
        public string mpresa { get; set; }
        public IList<Audiencia_tab> Audiencia_tab { get; set; }
        public IList<ActividadesProcessos> actividadesProcessos { get; set; }
        public Cliente_tb Cliente_Tb { get; set; }
        public Processo_tb processo_Tb { get; set; }
        public string processoId { get; set; }
        public string estatusdoevento { get; set; }
        public HtmlSanitizer sanitizer { get; set; } = new HtmlSanitizer();
        async Task lisdardaos( string id)
        {
            //agenda
            Audiencia_tab = await context.Audiencia_Tabs.Where(x => x.Processo_Tb.idempresas == id)
              .Include(a => a.Processo_Tb).AsNoTracking().ToListAsync();
            //actividades
            actividadesProcessos = await context.ActividadesProcessos.Where(x => x.idempresa == id)
                .Include(a => a.Processo_Tb).AsNoTracking().ToListAsync();
           

            ViewData["nclinte"] = await context.Cliente_Tbs.Where(x => x.idempresa == id).CountAsync();
            ViewData["nprocess"] = await context.Processo_Tbs.Where(x => x.idempresas == id && x.Estados == estadoss.Activo && x.tipo == tipo.Processo).CountAsync();
            ViewData["npcasos"] = await context.Processo_Tbs.Where(x => x.idempresas == id && x.Estados == estadoss.Activo && x.tipo == tipo.Caso).CountAsync();
            var em = context.Empresa_Tbs.Where(b => b.Ids == id).FirstOrDefault();
            logomarca = em.NomeEmpresa + "/" + em.LogoTipoEmpresa;
            mpresa = em.NomeEmpresa;
            //obter total de espaco usado
            string fullPath = Path.Combine(ihostingEnvironment.WebRootPath,"Escritorios/"+ em.NomeEmpresa + "/");
            var totalsize = GetDirectorySize(fullPath);
            ViewData["TotalUsado"] = totalsize;
        }
        public async Task OnGetAsync()
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {


                try
                {
                    var verlicenca =await context.PagamentoLicencas.FirstOrDefaultAsync(v => v.idempresa == user.idempresa || v.estadoss.Equals(estado.Agendado));
                    if (verlicenca ==null)
                    {
                        _logger.LogInformation("Nao possui uma conta paga");
                    }
                    _logger.LogInformation("Listar dados na pagina inicial");
                    await lisdardaos(user.idempresa);
            }
            catch (Exception ex)
            {
                    _logger.LogInformation(ex.Message);
                    throw new Exception( ex.Message);
            }
            }
            // notyf.Warning("total espaco " + totalsize);
        }
        private static long GetDirectorySize(string folderPath)
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);
            var tota = di.EnumerateFiles("*", SearchOption.AllDirectories).Sum(fi => fi.Length) ;
         var megas=   Math.Round((double)tota / (double)(1024 * 1024* 1024), 2);
            return (long)megas;
        }
        public async Task<JsonResult> OnGetCalendario()
        {
            var user = await userManager.GetUserAsync(User);
            var cale = await context.Audiencia_Tabs.Where(x => x.Processo_Tb.idempresas == user.idempresa).Include(a => a.Processo_Tb).ToListAsync();
            return new JsonResult(cale);
        }

        public List<Processo_tb> Customers { get; set; }

        
        public async Task<IActionResult> OnPostAutoComplete(string prefix)
        {
            var user = await userManager.GetUserAsync(User);
            var customers = await( from u in context.Processo_Tbs
                        join ut in context.Cliente_Tbs on u.Idcliente equals ut.Ids
                        where u.TituloProcesso.StartsWith(prefix) && u.idempresas==user.idempresa
                        select new
                        {
                            label = ut.buscarnomes() + "-" + u.TituloProcesso,
                            val = u.Ids
                        }).AsNoTracking().ToListAsync();
         

            return new JsonResult(customers);
        }
        public async Task<IActionResult> OnPostSubmit()
        {
            var user = await userManager.GetUserAsync(User);
            await lisdardaos(user.idempresa);
            try
            {
                var b = Request.Form["processoId"].ToString();
                //if (!b.Equals(""))
                //{

          var busca=      sanitizer.Sanitize(b);


                _logger.LogInformation("Buscar "+ busca);
                // this.Message = "CustomerName: " + Request.Form["CustomerName"] + " CustomerId: " + Request.Form["CustomerId"];
                return RedirectToPage("/Processo/Details", new { id = busca });
               // }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw ex;
            }
           
        }

    }
}
