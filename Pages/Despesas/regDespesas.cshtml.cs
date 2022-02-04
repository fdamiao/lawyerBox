using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeblawyersBox.Data;
using WeblawyersBox.Models;
using WeblawyersBox.servicos;

namespace WeblawyersBox.Pages.Despesas
{
    public class regDespesasModel : PageModel
    {
        private readonly INotyfService notyf;
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
   


        public regDespesasModel(INotyfService notyf, WeblawyersBox.Data.ApplicationDbContext context, IWebHostEnvironment ihostingEnvironment, UserManager<ApplicationUser> userManager)
        {

            this.notyf = notyf;
            _context = context;
            IhostingEnvironment = ihostingEnvironment;
            this.userManager = userManager;

        }


        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return RedirectToPage("/erro/Erro404");

            }
            return Page();
        }


        [BindProperty]
        public FacturacaoTbs FacturacaoTbs { get; set; }
        public fileHonorarios fileUpload { get; set; }
        public IWebHostEnvironment IhostingEnvironment { get; }
        public Processo_tb Processo_Tb { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(fileHonorarios fileUpload)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await userManager.GetUserAsync(User);
            var em = _context.Empresa_Tbs.Where(b => b.Ids == user.idempresa).FirstOrDefault();

            //guardaor os arquivos
            Processo_Tb = _context.Processo_Tbs.Where(b => b.Ids == FacturacaoTbs.idprocesso).FirstOrDefault();
            var cli = _context.Cliente_Tbs.Where(c => c.Ids == Processo_Tb.Idcliente).FirstOrDefault();

            string fullPath = Path.Combine(IhostingEnvironment.WebRootPath, em.NomeEmpresa + "/" + cli.Ids);
            if (!Directory.Exists(fullPath))
            {
                // _logger.LogInformation("criar directorio para a empresa em particula." + nomedaempresa);
                Directory.CreateDirectory(fullPath);
            }
            var fatura = new FacturacaoTbs();
            var aformFile = fileUpload.FormFiles;
            
                var formFile = aformFile;
                if (formFile.Length !=null )
                {
                    var files = Guid.NewGuid().ToString() + "_" + formFile.FileName;
                    var filePath = Path.Combine(fullPath, files);

                    using (var stream = System.IO.File.Create(filePath))
                    {

                        //await FileUpload.FormFile.CopyToAsync(stream);

                        // Upload the file if less than 2 MB
                        if (stream.Length < 2097152)
                        {

                            await formFile.CopyToAsync(stream);
                            FacturacaoTbs.comprovativo = files;

                        }
                        else
                        {
                            notyf.Error("o ficheiro celecionado é muito grande");
                            ModelState.AddModelError("File", "The file is too large.");
                            ViewData["SuccessMessage"] = "The file is too large.";
                        }


                    }
                }

                FacturacaoTbs.tipofacturacao = tipofacturacao.Despesas;
                FacturacaoTbs.Despesaestatus = despesaestatus.Realizado;

                _context.FacturacaoTBs.Add(FacturacaoTbs);
                await _context.SaveChangesAsync();
            
            return RedirectToPage("/Processo/Details", new { id = FacturacaoTbs.idprocesso });
        }
    }
}
