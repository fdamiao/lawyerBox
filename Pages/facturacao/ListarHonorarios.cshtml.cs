using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.facturacao
{
    public class ListarHonorariosModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public ListarHonorariosModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FacturacaoTbs> FacturacaoTbs { get;set; }

        public async Task OnGetAsync()
        {
            FacturacaoTbs = await _context.FacturacaoTBs.ToListAsync();
        }
    }
}
