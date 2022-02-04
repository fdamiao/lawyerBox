using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.PessoasEnvolvidas
{
    public class DetailsModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public DetailsModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
