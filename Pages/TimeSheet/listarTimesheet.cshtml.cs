using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.TimeSheet
{
    public class listarTimesheetModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public listarTimesheetModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<timesheetTbs> timesheetTbs { get;set; }

        public async Task OnGetAsync()
        {
            timesheetTbs = await _context.TimesheetTbs.ToListAsync();
        }
    }
}
