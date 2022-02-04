using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Lowyeslicencas
{
    public class CreateModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public CreateModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public pagamentoLicenca pagamentoLicenca { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PagamentoLicencas.Add(pagamentoLicenca);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
