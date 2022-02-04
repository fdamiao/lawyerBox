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
    public class CasosModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INotyfService notyf;

        public CasosModel(WeblawyersBox.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager, INotyfService notyf)
        {
            _context = context;
            this.userManager = userManager;
            this.notyf = notyf;
        }
        public Cliente_tb Cliente_Tb { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id==null)
            {
                return NotFound();
            }

            try
            {
                Processo_tb = _context.Processo_Tbs.Where(f => f.Ids == id).FirstOrDefault();
                if (Processo_tb == null)
                {
                    Cliente_Tb = _context.Cliente_Tbs.Where(f => f.Ids == id).FirstOrDefault();
                }
                else
                {
                    // Cliente_Tb = _context.Cliente_Tbs.Where(f => f.Processo_tb.Where == id).FirstOrDefault();
                    Cliente_Tb = _context.Cliente_Tbs.Where(f => f.Ids == Processo_tb.Idcliente).FirstOrDefault();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
            return Page();
        }

        [BindProperty]
        public Processo_tb Processo_tb { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Processo_tb.tipo = tipo.Caso;
            Processo_tb.instacia = instacia.NA;
           
            
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
            {
                b.idempresas = user.idempresa;
                b.tipo = tipo.Caso;
                b.Objecto = Processo_tb.Objecto;
                b.instacia= instacia.NA;
                b.Fisico = Processo_tb.Fisico;
                _context.Attach(b).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            notyf.Success("Caso criado com sucesso" );
            return RedirectToPage("/Processo/Details", new {id= Processo_tb.Ids });
        }
    }
}
