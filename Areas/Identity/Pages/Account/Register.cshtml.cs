using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using WeblawyersBox.Models;
using Microsoft.AspNetCore.Hosting;
using WeblawyersBox.Data;

namespace WeblawyersBox.Areas.Identity.Pages.Account
{
    [Authorize]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext db;
        private readonly RoleManager<ApplicationRole> roleManager;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
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
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [BindProperty]
            public IFormFile Photo { get; set; }

            [Required]
            [Display(Name = "Nome do escritorio")]
            [DataType(DataType.Text)]
            public string nomeescritorio { get; set; }
            [Required]
            [Display(Name = "Nome")]
            [DataType(DataType.Text)]
            public string nome { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Apelido")]
            public string apelido { get; set; }
            
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }
        public ApplicationRole applicationRole { get; set; }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                //croar a empresa
                Empresa_tb em = new Empresa_tb();
                em.NomeEmpresa = Input.nomeescritorio;
                em.LogoTipoEmpresa = ProcessUploadedFile(em.NomeEmpresa);
                db.Empresa_Tbs.Add(em);
               await db.SaveChangesAsync();
                //depos relacionar com o usario
                var user = new ApplicationUser {
                    Nome = Input.nome,
                    apelido = Input.apelido,
                    UserName = Input.Email,
                    Email = Input.Email,
                    idempresa = em.Ids
                    
                };
               
                var result = await _userManager.CreateAsync(user, Input.Password);
               
                    await roleManager.CreateAsync(new ApplicationRole("Administrador", "Administrador", DateTime.Now));

                    await _userManager.AddToRoleAsync(user, "Administrador");
                
                if (result.Succeeded)
                {
                    //Creating upload folder  

                   


                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        private string ProcessUploadedFile(string nomedaempresa)
        {
            string uniqueFileName = null;

            if (Input.Photo != null)
            {
                //criar directorio para a empresa em partiula
                string fullPath = Path.Combine(_env.WebRootPath, nomedaempresa);
                if (!Directory.Exists(fullPath))
                {
                    _logger.LogInformation("criar directorio para a empresa em particula."+ nomedaempresa);
                    Directory.CreateDirectory(fullPath);
                }
                string uploadsFolder = fullPath;
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Input.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Input.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
