using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Despesas
{
    public class listarDespesaModel : PageModel
    {
        private readonly ILogger<listarDespesaModel> logger;
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public listarDespesaModel(ILogger<listarDespesaModel> logger,WeblawyersBox.Data.ApplicationDbContext context)
        {
            this.logger = logger;
            _context = context;
        }

        public IList<FacturacaoTbs> despesad { get;set; }

        public async Task OnGetAsync()
        {
            despesad = await _context.FacturacaoTBs.ToListAsync();
        }
    }
}
