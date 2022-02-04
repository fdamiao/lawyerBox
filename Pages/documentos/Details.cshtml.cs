using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.documentos
{
    public class DetailsModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public DetailsModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Documentos_Processos_tb Documentos_Processos_tb { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Documentos_Processos_tb = await _context.Documentos_Processos_Tbs
                .Include(d => d.idProcessoNavigation).FirstOrDefaultAsync(m => m.Ids == id);

            if (Documentos_Processos_tb == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
