using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Lowyeslicencas
{
    public class DeleteModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public DeleteModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public pagamentoLicenca pagamentoLicenca { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            pagamentoLicenca = await _context.PagamentoLicencas.FirstOrDefaultAsync(m => m.Ids == id);

            if (pagamentoLicenca == null)
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

            pagamentoLicenca = await _context.PagamentoLicencas.FindAsync(id);

            if (pagamentoLicenca != null)
            {
                _context.PagamentoLicencas.Remove(pagamentoLicenca);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
