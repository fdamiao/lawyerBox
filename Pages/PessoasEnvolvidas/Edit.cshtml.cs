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

namespace WeblawyersBox.Pages.PessoasEnvolvidas
{
    public class EditModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public EditModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pessoas_Envolvidas_tb Pessoas_Envolvidas_tb { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pessoas_Envolvidas_tb = await _context.Pessoas_Envolvidas_Tbs
                .Include(p => p.idProcessoNavigation).FirstOrDefaultAsync(m => m.Ids == id);

            if (Pessoas_Envolvidas_tb == null)
            {
                return NotFound();
            }
           ViewData["idProcesso"] = new SelectList(_context.Processo_Tbs, "Ids", "Ids");
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

            _context.Attach(Pessoas_Envolvidas_tb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pessoas_Envolvidas_tbExists(Pessoas_Envolvidas_tb.Ids))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Pessoas_Envolvidas_tbExists(string id)
        {
            return _context.Pessoas_Envolvidas_Tbs.Any(e => e.Ids == id);
        }
    }
}
