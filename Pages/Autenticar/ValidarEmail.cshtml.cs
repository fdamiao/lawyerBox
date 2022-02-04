using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using WeblawyersBox.Data;
using WeblawyersBox.Models;
using WeblawyersBox.Pages.EmaiSservice;
using static WeblawyersBox.Email.EnviarEmailCliente;

namespace WeblawyersBox.Pages.Autenticar
{
    [AllowAnonymous]
    public class ValidarEmailModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ValidarEmailModel> _logger;
        private readonly IEmailSenders _emailSender;
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext db;
        private readonly RoleManager<ApplicationRole> roleManager;
        public ValidarEmailModel(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ValidarEmailModel> logger,
            IEmailSenders emailSender,
            IWebHostEnvironment webHostEnvironment,
            ApplicationDbContext applicationDbContext, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _env = webHostEnvironment;
            this.db = applicationDbContext;
            this.roleManager = roleManager;
        }
        [BindProperty]
        public string email { get; set; }
        public async Task<IActionResult>  OnGet(string id)
        {
        
            
            email = id;
            _logger.LogInformation("User created a new account with password.");

           
            return Page();
        }
    }
}