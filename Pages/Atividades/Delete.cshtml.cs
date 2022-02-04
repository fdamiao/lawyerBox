using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Atividades
{
    public class DeleteModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public DeleteModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ActividadesProcessos ActividadesProcessos { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActividadesProcessos = await _context.ActividadesProcessos.FirstOrDefaultAsync(m => m.Ids == id);

            if (ActividadesProcessos == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActividadesProcessos = await _context.ActividadesProcessos.FindAsync(id);

            if (ActividadesProcessos != null)
            {
                _context.ActividadesProcessos.Remove(ActividadesProcessos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
