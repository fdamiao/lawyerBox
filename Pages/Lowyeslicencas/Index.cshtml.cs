using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Lowyeslicencas
{
    public class IndexModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public IndexModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<pagamentoLicenca> pagamentoLicenca { get;set; }

        public async Task OnGetAsync()
        {
            pagamentoLicenca = await _context.PagamentoLicencas.ToListAsync();
        }
    }
}
