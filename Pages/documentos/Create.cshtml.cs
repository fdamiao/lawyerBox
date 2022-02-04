using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeblawyersBox.Data;
using WeblawyersBox.Models;
using WeblawyersBox.servicos;

namespace WeblawyersBox.Pages.documentos
{
    public class CreateModel : PageModel
    {
        private readonly INotyfService notyf;
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
                 private IWebHostEnvironment _ihostingEnvironment;
        private readonly UserManager<ApplicationUser> userManager;

        public CreateModel(INotyfService notyf,WeblawyersBox.Data.ApplicationDbContext context, IWebHostEnvironment ihostingEnvironment, UserManager<ApplicationUser> userManager)
        {
            this.notyf = notyf;
            _context = context;
            _ihostingEnvironment = ihostingEnvironment;
            this.userManager = userManager;
        }
        [BindProperty]
        public fileUpload fileUpload { get; set; }
        //upload action as shown:
      //  private string fullPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "UploadImages/";

        public List<string> FileNames { get; set; }
        public IActionResult OnGet(string id)
        {
                //  ViewData["idProcesso"] = new SelectList(_context.Processo_Tbs, "Ids", "Ids");
                Processo_Tb = _context.Processo_Tbs.Where(b => b.Ids == id).FirstOrDefault();

            ViewData["SuccessMessage"] = "";
            return Page();
        }

        [BindProperty]
        public Documentos_Processos_tb Documentos_Processos_tb { get; set; }
        public Processo_tb Processo_Tb { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(fileUpload fileUpload)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await userManager.GetUserAsync(User);
            var em = _context.Empresa_Tbs.Where(b => b.Ids == user.idempresa).FirstOrDefault();
           
            //guardaor os arquivos
            Processo_Tb = _context.Processo_Tbs.Where(b => b.Ids == Documentos_Processos_tb.idProcesso).FirstOrDefault();
            var cli = _context.Cliente_Tbs.Where(c => c.Ids == Processo_Tb.Idcliente).FirstOrDefault();
           


            string fullPath = Path.Combine(_ihostingEnvironment.WebRootPath, "Escritorios/"+ em.NomeEmpresa + "/" + cli.Ids.Replace("-","").ToUpper()+"/"+Processo_Tb.tipo+"-"+Processo_Tb.TituloProcesso );
            if (!Directory.Exists(fullPath))
            {
                // _logger.LogInformation("criar directorio para a empresa em particula." + nomedaempresa);
                Directory.CreateDirectory(fullPath);
            }
            foreach (var aformFile in fileUpload.FormFiles)
            {
                var formFile = aformFile;
                if (formFile.Length > 0)
                {
              var files=      Guid.NewGuid().ToString() + "_" + formFile.FileName;
                    var filePath = Path.Combine(fullPath, files);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        
                            //await FileUpload.FormFile.CopyToAsync(stream);
                           
                            // Upload the file if less than 2 MB
                            if (stream.Length < 2097152)
                            {

                            await formFile.CopyToAsync(stream);
                            var file = new Documentos_Processos_tb()
                            {
                                nomeDoc = formFile.FileName,

                                ContentType = formFile.ContentType,
                               // docomnto = files,
                                NomeFicheiro = files,
                                idProcesso=Documentos_Processos_tb.idProcesso,
                                Iduser= user.Id.ToString(),
                            };

                                _context.Documentos_Processos_Tbs.Add(file);

                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                ModelState.AddModelError("File", "The file is too large.");
                            ViewData["SuccessMessage"] = "The file is too large.";
                            }
                        
                        
                    }
                }
            }

            // Process uploaded files  
            // Don't rely on or trust the FileName property without validation.  
            notyf.Success("Documentos salvos com sucesso");

            return RedirectToPage("/Processo/Details",new { id=Documentos_Processos_tb.idProcesso});
        }
    }
}
