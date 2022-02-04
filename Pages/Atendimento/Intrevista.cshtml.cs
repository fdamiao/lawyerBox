using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ganss.XSS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Atendimento
{
    public class IntrevistaModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public IntrevistaModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string id)
        {
            if (id!=null)
            {
                Intrevistas = _context.Intrevistas.FirstOrDefault(g => g.Ids == id);
            }
            return Page();
        }

        [BindProperty]
        public Intrevistas Intrevistas { get; set; }
        //proteger contra javascript crxx
        public HtmlSanitizer sanitizer { get; set; } = new HtmlSanitizer();

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           var b = _context.Intrevistas.FirstOrDefault(g => g.Ids == Intrevistas.Ids);
            if (b != null)
            {
                b.DescricaoActividade = sanitizer.Sanitize(Intrevistas.DescricaoActividade);
                _context.Attach(b).State = EntityState.Modified;
            }
            else
            {
                _context.Intrevistas.Add(Intrevistas);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/Processo/Details", new { id = Intrevistas.idprocesso });
        }
    }
}
