using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Processo
{
    public class CreateModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public CreateModel(WeblawyersBox.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        public Cliente_tb Cliente_Tbs { get; set; }
        public List<SelectListItem> tpprocesso { get; set; }
        public async Task< IActionResult> OnGet()
        {

        
            tpprocesso =await _context.TpProcessos.Select(a =>
                                 new SelectListItem
                                 {
                                     Value = a.Ids.ToString(),
                                     Text = a.descricao
                                 }).ToListAsync();
            ViewData["idTpprocesso"] = tpprocesso;
            return Page();
        }

        [BindProperty]
        public Processo_tb Processo_tb { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await userManager.GetUserAsync(User);
            Processo_tb.idempresas = user.idempresa;
            if (!ModelState.IsValid)
            {
                //tpprocesso = _context.TpProcessos.Select(a =>
                //              new SelectListItem
                //              {
                //                  Value = a.Ids.ToString(),
                //                  Text = a.descricao
                //              }).ToList();
                //ViewData["idTpprocesso"] = tpprocesso;
                return Page();
            }

            //_context.Processo_Tbs.Add(Processo_tb);
            //await _context.SaveChangesAsync();

            return RedirectToPage("/Processo/Details", new { Processo_tb.Ids });
        }
    }
}
