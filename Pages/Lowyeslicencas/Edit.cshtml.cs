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

namespace WeblawyersBox.Pages.Lowyeslicencas
{
    public class EditModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public EditModel(WeblawyersBox.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(pagamentoLicenca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pagamentoLicencaExists(pagamentoLicenca.Ids))
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

        private bool pagamentoLicencaExists(string id)
        {
            return _context.PagamentoLicencas.Any(e => e.Ids == id);
        }
    }
}
