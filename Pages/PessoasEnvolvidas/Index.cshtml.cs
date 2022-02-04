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
    public class IndexModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public IndexModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Pessoas_Envolvidas_tb> Pessoas_Envolvidas_tb { get;set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pessoas_Envolvidas_tb = await _context.Pessoas_Envolvidas_Tbs
                .Include(p => p.idProcessoNavigation).ToListAsync();
            return Page();
        }
    }
}
