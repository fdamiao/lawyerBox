using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.TimeSheet
{
    public class timesheetModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public timesheetModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string id)
        {
            Processo_Tb = _context.Processo_Tbs.FirstOrDefault(p => p.Ids == id);
            return Page();
        }

        [BindProperty]
        public timesheetTbs timesheetTbs { get; set; }
        public Processo_tb Processo_Tb { get; set; }
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TimesheetTbs.Add(timesheetTbs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
