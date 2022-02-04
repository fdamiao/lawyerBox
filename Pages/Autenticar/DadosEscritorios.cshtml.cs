using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Autenticar
{
    public class DadosEscritoriosModel : PageModel
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public DadosEscritoriosModel(IWebHostEnvironment webHostEnvironment, WeblawyersBox.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.webHostEnvironment = webHostEnvironment;
            _context = context;
            this.userManager = userManager;
        }

        [BindProperty]
        public Empresa_tb Empresa_tb { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
          
                var user = await userManager.GetUserAsync(User);
                if (user.idempresa== null)
            {
                return NotFound();
            }

            Empresa_tb = await _context.Empresa_Tbs.FirstOrDefaultAsync(m => m.Ids == user.idempresa);

            if (Empresa_tb == null)
            {
                return NotFound();
            }
            return Page();
        }
        [BindProperty]
        public IFormFile Photo { get; set; }
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile formFile)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Photo = formFile;
            Empresa_tb.LogoTipoEmpresa = ProcessUploadedFile(Empresa_tb.NomeEmpresa);
            _context.Attach(Empresa_tb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Empresa_tbExists(Empresa_tb.Ids))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Index");
        }

        private bool Empresa_tbExists(string id)
        {
            return _context.Empresa_Tbs.Any(e => e.Ids == id);
        }
        private string ProcessUploadedFile(string nomedaempresa)
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                              string fullPath = Path.Combine(webHostEnvironment.WebRootPath, "Escritorios/" + nomedaempresa);
                if (!Directory.Exists(fullPath))
                {
                    //_logger.LogInformation("criar directorio para a empresa em particula." + nomedaempresa);
                    Directory.CreateDirectory(fullPath);
                }
                string uploadsFolder = fullPath;
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
