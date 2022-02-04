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

namespace WeblawyersBox.Pages.Processo
{
    public class ActualizarstatusModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly INotyfService notyf;
        private readonly UserManager<ApplicationUser> userManager;

        public ActualizarstatusModel(WeblawyersBox.Data.ApplicationDbContext context, INotyfService notyf, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.notyf = notyf;
            this.userManager = userManager;
        }
        [BindProperty]
        public Processo_tb Processo_tb { get; set; }
        public Cliente_tb Cliente_Tb { get; set; }
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
          
               
                // Cliente_Tb = _context.Cliente_Tbs.Where(f => f.Processo_tb.Where == id).FirstOrDefault();
            
            return Page();
        }

        [BindProperty]
        public EstatusProcess EstatusProcess { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Processo_tb = _context.Processo_Tbs.Where(f => f.Ids == EstatusProcess.Idprocesso).FirstOrDefault();
         
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //actualizar o processo
            var user = await userManager.GetUserAsync(User);
            Processo_tb = _context.Processo_Tbs.Where(f => f.Ids == EstatusProcess.Idprocesso).FirstOrDefault();
            Processo_tb.Estados =(estadoss) EstatusProcess.status;
            EstatusProcess.Iduser = user.Email;
            EstatusProcess.Idprocesso = Request.Query["id"].ToString();
            _context.EstatusProcesses.Add(EstatusProcess);
            
            await _context.SaveChangesAsync();

            notyf.Success("estatus  salvos com sucesso");

            return RedirectToPage("/Processo/Details", new { id = EstatusProcess.Idprocesso });
        }
        //public async Task<IActionResult> OnPostAtualizarStatusAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.EstatusProcesses.Add(EstatusProcess);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
