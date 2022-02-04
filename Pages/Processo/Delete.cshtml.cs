using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Processo
{
    public class DeleteModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public DeleteModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Processo_tb Processo_tb { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Processo_tb = await _context.Processo_Tbs.FirstOrDefaultAsync(m => m.Ids == id);

            if (Processo_tb == null)
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

            Processo_tb = await _context.Processo_Tbs.FindAsync(id);

            if (Processo_tb != null)
            {
                _context.Processo_Tbs.Remove(Processo_tb);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
