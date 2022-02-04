using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Processo
{
    public class editardecricaoModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly INotyfService notyf;
        private readonly UserManager<ApplicationUser> userManager;

        public editardecricaoModel(WeblawyersBox.Data.ApplicationDbContext context, INotyfService notyf, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.notyf = notyf;
            this.userManager = userManager;
        }

        [BindProperty]
        public Processo_tb Processo_tb { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Processo_tb = await _context.Processo_Tbs.FirstOrDefaultAsync(m => m.Ids == id);
         
            if (Processo_tb == null)
            {
                return NotFound();
            }
            return Page();
        }

     
        public async Task<IActionResult> OnPostAsync()
        {
       
            Processo_tb.Estados = estadoss.Activo;
            var user = await userManager.GetUserAsync(User);
            Processo_tb.idempresas = user.idempresa;
            Processo_tb.Iduser = user.Email;
            Processo_tb.Idcliente = Request.Query["id"].ToString();

            if (!ModelState.IsValid)
            {
                return Page();
            }

           _context.Attach(Processo_tb).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
                notyf.Success("Descricao actulizado com sucesso");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Processo_tbExists(Processo_tb.Ids))
                {
                    notyf.Error("processo nao encontrado");
                    return NotFound();

                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Processo/Details", new { id = Processo_tb.Ids });

        }

        private bool Processo_tbExists(string id)
        {
            return _context.Processo_Tbs.Any(e => e.Ids == id);
        }
    }
}
