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
    public class ProcessosModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INotyfService notyf;

        public ProcessosModel(WeblawyersBox.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager, INotyfService notyf)
        {
            _context = context;
            this.userManager = userManager;
            this.notyf = notyf;
        }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cliente_Tb = _context.Cliente_Tbs.Where(f => f.Ids == id).FirstOrDefault();
            if (Cliente_Tb == null)
            {
                Processo_tb = _context.Processo_Tbs.Where(f => f.Ids == id).FirstOrDefault();
                // Cliente_Tb = _context.Cliente_Tbs.Where(f => f.Processo_tb.Where == id).FirstOrDefault();
            }
            return Page();
        }

        [BindProperty]
        public Processo_tb Processo_tb { get; set; }
        public Cliente_tb  Cliente_Tb { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Processo_tb.tipo = tipo.Processo;
            Processo_tb.Estados = estadoss.Activo;
            var user = await userManager.GetUserAsync(User);
            Processo_tb.idempresas = user.idempresa;
            Processo_tb.Iduser = user.Email;
            Processo_tb.Idcliente = Request.Query["id"].ToString();



            if (!ModelState.IsValid)
            {
                return Page();
            }
            var b = await _context.Processo_Tbs.Where(f => f.Ids == Processo_tb.Ids).FirstOrDefaultAsync();
            if (b == null)
            {
                _context.Processo_Tbs.Add(Processo_tb);
            }
            else
                _context.Attach(Processo_tb).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            notyf.Success("processo criado com sucesso");
            return RedirectToPage("/Processo/Details", new {id= Processo_tb.Ids });
        }
    }
}
