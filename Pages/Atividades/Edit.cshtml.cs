using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Atividades
{
    public class EditModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public EditModel(WeblawyersBox.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ActividadesProcessos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadesProcessosExists(ActividadesProcessos.Ids))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Processo/Details", new { id = ActividadesProcessos.idprocesso });
        }

        private bool ActividadesProcessosExists(string id)
        {
            return _context.ActividadesProcessos.Any(e => e.Ids == id);
        }
    }
}
