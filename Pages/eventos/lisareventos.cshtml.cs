using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.eventos
{
    public class lisareventosModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public lisareventosModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Audiencia_tab> Audiencia_tab { get;set; }

        public async Task OnGetAsync()
        {
            Audiencia_tab = await _context.Audiencia_Tabs
                .Include(a => a.Processo_Tb).ToListAsync();
        }
    }
}
