using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Lowyeslicencas
{
    public class criarlicensasModel : PageModel
    {
        private readonly ILogger<criarlicensasModel> logger;
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public criarlicensasModel(ILogger<criarlicensasModel> logger,WeblawyersBox.Data.ApplicationDbContext context)
        {
            this.logger = logger;
            _context = context;
        }

        public IList<licensastbs> Listlicensastbs { get; set; }

        public async Task OnGetAsync( string id)
        {
            if (id!=null)
            {
                licensastbs = await _context.licensastbs.Where(f=>f.idlices==id).AsNoTracking().FirstOrDefaultAsync();
            }
           
            Listlicensastbs = await _context.licensastbs.ToListAsync();
        
        //   return Page();
        }

        [BindProperty]
        public licensastbs licensastbs { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {

           
           var  b = await _context.licensastbs.Where(f => f.idlices == licensastbs.idlices).AsNoTracking().FirstOrDefaultAsync();
                if (b == null)
                {
                    licensastbs.idlices =Guid. NewGuid().ToString();
                    _context.licensastbs.Add(licensastbs);
                }
                else
                {
                    _context.Attach(licensastbs).State = EntityState.Modified;
                }

            await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }

            return RedirectToPage("./criarlicensas");
        }
    }
}
