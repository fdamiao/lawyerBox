using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WeblawyersBox.Pages.Autenticar
{
    public class ConfirmaEmailModel : PageModel
    {
        [BindProperty]
        public string email { get; set; }
        public IActionResult OnGet(string id)
        {
            email = id;
            return Page();
        }
    }
}