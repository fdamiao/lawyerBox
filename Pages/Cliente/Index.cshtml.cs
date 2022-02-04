using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Cliente
{
    public class IndexModel : PageModel
    {
        private readonly INotyfService notyf;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public IndexModel(INotyfService notyf, IWebHostEnvironment webHostEnvironment,WeblawyersBox.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.notyf = notyf;
            this.webHostEnvironment = webHostEnvironment;
            _context = context;
            this.userManager = userManager;
        }
        public Cliente_tb cliente_Tb { get; set; }
        public PartialViewResult OnPostSalvarclinte()
        {
            if (ModelState.IsValid)
            {
                _context.Cliente_Tbs.Add(cliente_Tb);
            }
            // this handler returns _ContactModalPartial
            return new PartialViewResult
            {

                ViewName = "_NovoCliente",
                ViewData = new ViewDataDictionary<Cliente_tb>(ViewData, new Cliente_tb { })
            };
        }
        public PartialViewResult OnGetNovoCliente()
        {

            // this handler returns _ContactModalPartial
            return new PartialViewResult
            {

                ViewName = "_NovoCliente",
                ViewData = new ViewDataDictionary<Cliente_tb>(ViewData, new Cliente_tb { })
            };
        }

        public IList<Cliente_tb> Cliente_tb { get;set; }

        public async Task OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await userManager.GetUserAsync(User);
                Cliente_tb = await _context.Cliente_Tbs.Where(x => x.idempresa == user.idempresa).ToListAsync();
            }
          //  Cliente_tb = await _context.Cliente_Tbs.ToListAsync();
        }
    }
}
