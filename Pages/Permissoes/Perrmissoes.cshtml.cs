using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Permissoes
{
    public class PerrmissoesModel : PageModel
    {
        private readonly ApplicationDbContext context;
        private readonly RoleManager<ApplicationRole> roleManager;

        public PerrmissoesModel(ApplicationDbContext context, RoleManager<ApplicationRole> roleManager)
        {
            this.context = context;
            this.roleManager = roleManager;
            context.Database.EnsureCreated();
        }
        [BindProperty]
        public ApplicationRole applicationRole { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (await roleManager.FindByNameAsync(applicationRole.Name) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(applicationRole.Name, applicationRole.descricao, DateTime.Now));
            }
            return RedirectToPage("./Index");
        }
    }
}