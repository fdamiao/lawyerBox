using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.eventos
{
    public class CriarEventosModel : PageModel
    {
        private readonly ILogger<CriarEventosModel> logger;
        private readonly INotyfService notyf;
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public CriarEventosModel(ILogger<CriarEventosModel> logger, INotyfService notyf,WeblawyersBox.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.logger = logger;
            this.notyf = notyf;
            _context = context;
            this.userManager = userManager;
        }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return RedirectToPage("/erro/Erro404");

            }
           
            Processo_Tb = _context.Processo_Tbs.FirstOrDefault(p => p.Ids == id);
            return Page();
        }

        [BindProperty]
        public Audiencia_tab Audiencia_tab { get; set; }
        public Processo_tb Processo_Tb { get; set; }
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Audiencia_tab.idProcesso = Request.Query["id"].ToString();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                var user = await userManager.GetUserAsync(User);

                Audiencia_tab.idempresa = user.idempresa;
                Audiencia_tab.Iduser = user.Email;

                _context.Audiencia_Tabs.Add(Audiencia_tab);
                await _context.SaveChangesAsync();
                logger.LogInformation("Criar eventos com sucesso"+ Audiencia_tab.evento);
                notyf.Success("Evento "+ Audiencia_tab.evento+" criaddo com sucesso");
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToPage("/Processo/Details", new { id = Audiencia_tab.idProcesso });
        }
    }
}
