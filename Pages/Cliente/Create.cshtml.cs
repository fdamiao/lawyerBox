using System;
using System.Collections.Generic;
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
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Cliente
{
    public class CreateModel : PageModel
    {
        private readonly INotyfService notyf;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateModel(INotyfService notyf,IWebHostEnvironment webHostEnvironment, WeblawyersBox.Data.ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            this.notyf = notyf;
            this.webHostEnvironment = webHostEnvironment;
           
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        
            UserManager = userManager;

        }

        public async Task<IActionResult> OnGet(string id)
        {
            if (id != null)
            {
                Cliente_tb = await _context.Cliente_Tbs.FirstOrDefaultAsync(m => m.Ids == id);
                if (Cliente_tb == null)
                {
                    return NotFound();
                }
            }

          

           

            return Page();
        }

        [BindProperty]
        public Cliente_tb Cliente_tb { get; set; }
        public UserManager<ApplicationUser> UserManager { get; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await UserManager.GetUserAsync(User);

            Cliente_tb.idempresa = user.idempresa;
            if (!ModelState.IsValid)
            {
                return Page();
            }
          var b= await _context.Cliente_Tbs.FirstOrDefaultAsync(m => m.Ids == Cliente_tb.Ids);
            if (b == null)
            {

                _context.Cliente_Tbs.Add(Cliente_tb);
            }
            else
            {
                _context.Attach(Cliente_tb).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            notyf.Success("Cliente cadastrado com sucesso");
            var em = _context.Empresa_Tbs.Where(b => b.Ids == user.idempresa).FirstOrDefault();
            string fullPath = Path.Combine(webHostEnvironment.WebRootPath,"/Escritorios/"+ em.NomeEmpresa + "/" + Cliente_tb.Ids);
            if (!Directory.Exists(fullPath))
            {
                // _logger.LogInformation("criar directorio para a empresa em particula." + nomedaempresa);
                Directory.CreateDirectory(fullPath);
            }
            return RedirectToPage("/Processo/index", new { id=Cliente_tb.Ids});
        }
    }
}
