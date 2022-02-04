using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Ganss.XSS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Atividades
{
    public class NovaActividadeModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<NovaActividadeModel> logger;
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly INotyfService notyf;

        public NovaActividadeModel(UserManager<ApplicationUser> userManager,ILogger<NovaActividadeModel> logger,WeblawyersBox.Data.ApplicationDbContext context, INotyfService notyf)
        {
            this.userManager = userManager;
            this.logger = logger;
            _context = context;
            this.notyf = notyf;
        }

        public IActionResult OnGet(string id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Processo_Tb = _context.Processo_Tbs.FirstOrDefault(g => g.Ids == id);
            return Page();
        }

        [BindProperty]
        public ActividadesProcessos ActividadesProcessos { get; set; }
        public Processo_tb Processo_Tb { get; set; }
        public HtmlSanitizer sanitizer { get; set; } = new HtmlSanitizer();
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            ActividadesProcessos.idprocesso =Request.Query["id"].ToString();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await userManager.GetUserAsync(User);

            ActividadesProcessos.idempresa = user.idempresa;
            ActividadesProcessos.Iduser = user.Email;
            
            ActividadesProcessos.Descricaoactividades = sanitizer.Sanitize(ActividadesProcessos.Descricaoactividades);
            _context.ActividadesProcessos.Add(ActividadesProcessos);
            await _context.SaveChangesAsync();
            notyf.Success("Actividades criada com cucesso");
            return RedirectToPage("/Processo/Details", new { id = ActividadesProcessos.idprocesso });
        }
    }
}
