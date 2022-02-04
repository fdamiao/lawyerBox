using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WeblawyersBox.Pages.Autenticar
{
    public class privacidadeModel : PageModel
    {
        [AllowAnonymous]
        public void OnGet()
        {

        }
    }
}