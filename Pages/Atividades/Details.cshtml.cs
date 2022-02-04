using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Atividades
{
    public class DetailsModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public DetailsModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ActividadesProcessos ActividadesProcessos { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActividadesProcessos = await _context.ActividadesProcessos.FirstOrDefaultAsync(m => m.Ids == id);

            if (ActividadesProcessos == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
