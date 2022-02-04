using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Cliente
{
    public class DeleteModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public DeleteModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente_tb Cliente_tb { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente_tb = await _context.Cliente_Tbs.FirstOrDefaultAsync(m => m.Ids == id);

            if (Cliente_tb == null)
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

            Cliente_tb = await _context.Cliente_Tbs.FindAsync(id);

            if (Cliente_tb != null)
            {
                _context.Cliente_Tbs.Remove(Cliente_tb);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
