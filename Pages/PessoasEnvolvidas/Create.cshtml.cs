using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.PessoasEnvolvidas
{
    public class CreateModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly INotyfService notyf;
        private readonly UserManager<ApplicationUser> userManager;

        public CreateModel(WeblawyersBox.Data.ApplicationDbContext context, INotyfService notyf, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.notyf = notyf;
            this.userManager = userManager;
        }

        public IActionResult OnGet()
        {
      //  ViewData["idProcesso"] = new SelectList(_context.Processo_Tbs, "Ids", "Ids");
            return Page();
        }

        [BindProperty]
        public Pessoas_Envolvidas_tb Pessoas_Envolvidas_tb { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Pessoas_Envolvidas_tb.idProcesso = Request.Query["id"].ToString();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await userManager.GetUserAsync(User);
          //  Pessoas_Envolvidas_tb.idempresas = user.idempresa;
            Pessoas_Envolvidas_tb.Iduser = user.Email;
           

            _context.Pessoas_Envolvidas_Tbs.Add(Pessoas_Envolvidas_tb);
            await _context.SaveChangesAsync();
            notyf.Success("novos participantes adicionados");
            return RedirectToPage("/Processo/Details", new { id = Pessoas_Envolvidas_tb.idProcesso });

        }
    }
}
