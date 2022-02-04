using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeblawyersBox.Data;
using WeblawyersBox.Models;
using WeblawyersBox.Pages.EmaiSservice;
using WeblawyersBox.servicos;
using static WeblawyersBox.Email.EnviarEmailCliente;

namespace WeblawyersBox.Pages.Autenticar
{
    [AllowAnonymous]
    public class CadastroModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSenders _emailSender;
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext db;
        private readonly RoleManager<ApplicationRole> roleManager;
        public CadastroModel(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
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
          //  [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})")]
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
       
        public void Envianotificacao()
        {
            //agenda
            var Audiencia_tabs = db.Audiencia_Tabs.Where(x => x.Estado == estado.Agendado)
                  .Include(a => a.Processo_Tb).AsNoTracking().ToList();
            if (Audiencia_tabs != null)
            {


                foreach (var item in Audiencia_tabs)
                {
                    var totaldia = item.DataMarcada.Date.Subtract(DateTime.Now.Date).TotalDays;
                    //alerta para 2 dias
                    if (totaldia == 2)
                    {
                        //'envir notificacao

                        var message = new Message(item.responsavel, $"{item.evento}-daqui a 2 dias", $"Prezado, Temos agendado para o dia : {item.DataMarcada}, fazer {item.descricaevento} , No {item.LocaldaAudiencia}");
                        _emailSender.SendEmail(message);
                        _logger.LogInformation("2-email eniado com sucesso para" + message.To);
                    }
                    //alerta par 1 dias
                    if (totaldia == 1)
                    {
                        //'envir notificacao

                        var message = new Message(item.responsavel, $"{item.evento}-Para amanha ", $"Prezado, Temos agendado para  amanha : {item.DataMarcada}, fazer {item.descricaevento} ,  {item.LocaldaAudiencia}");
                        _emailSender.SendEmail(message);
                        _logger.LogInformation("1-email eniado com sucesso para" + message.To);
                    }
                    if (totaldia == 0)
                    {
                        //'envir notificacao

                        var message = new Message(item.responsavel, $"{item.evento}-Para Hoje ", $"Prezado, Temos agendado para  Hoje : {item.DataMarcada},<br> fazer {item.descricaevento} ,  {item.LocaldaAudiencia}");
                        _emailSender.SendEmail(message);
                        _logger.LogInformation("0-email eniado com sucesso para" + message.To);
                    }
                    if (totaldia <= 0)
                    {
                        //'envir notificacao

                        var message = new Message(item.responsavel, $"{item.evento}-atrazado a {totaldia} ", $"Prezado, Temos agendado para  Hoje : {item.DataMarcada},<br> fazer {item.descricaevento} ,  {item.LocaldaAudiencia}");
                        _emailSender.SendEmail(message);
                        _logger.LogInformation("atrazados-email eniado com sucesso para" + message.To);
                    }
                }
            }
            else
            {
                _logger.LogInformation("Nada agendado para os proximos dias");
            }
        } 
        //notificacao de actividades
        public void EnvianotificacaoActividades()
        {
            //agenda
            var Audiencia_tabs = db.ActividadesProcessos.Where(x => x.status == estado.Agendado)
                  .Include(a => a.Processo_Tb).AsNoTracking().ToList();
            if (Audiencia_tabs != null)
            {


                foreach (var item in Audiencia_tabs)
                {
                    var totaldia = item.data.Date.Subtract(DateTime.Now.Date).TotalDays;
                    //alerta para 2 dias
                    if (totaldia == 2)
                    {
                        //'envir notificacao

                        var message = new Message(item.responsavel, $"{item.Processo_Tb.TituloProcesso}-da qui a 2 dias", $"Prezado, Temos agendado para o dia : {item.data}, fazer {item.Descricaoactividades}");
                        _emailSender.SendEmail(message);
                        _logger.LogInformation("Actividade 2-email eniado com sucesso para" + message.To);
                    }
                    //alerta par 1 dias
                    if (totaldia == 1)
                    {
                        //'envir notificacao

                        var message = new Message(item.responsavel, $"{item.Processo_Tb.TituloProcesso}-amanha", $"Prezado, Temos agendado para o dia : {item.data}, fazer {item.Descricaoactividades}");
                        _emailSender.SendEmail(message);
                        _logger.LogInformation("actividades 1-email eniado com sucesso para" + message.To);
                    }
                    if (totaldia == 0)
                    {
                        //'envir notificacao

                        var message = new Message(item.responsavel, $"{item.Processo_Tb.TituloProcesso}-Para hoje", $"Prezado, Temos agendado para o dia : {item.data}, fazer {item.Descricaoactividades}");
                        _emailSender.SendEmail(message);
                        _logger.LogInformation("actividades 0-email eniado com sucesso para" + message.To);
                    }
                    if (totaldia <= 0)
                    {
                        //'envir notificacao

                        var message = new Message(item.responsavel, $"{item.Processo_Tb.TituloProcesso}-atrazado {totaldia} ", $"Prezado, Temos agendado para o dia : {item.data}, fazer {item.Descricaoactividades}");
                        _emailSender.SendEmail(message);
                        _logger.LogInformation("0-email eniado com sucesso para" + message.To);
                    }
                }
            }
            else
            {
                _logger.LogInformation("nada agendado para os proximos dias");
            }
        }
        public ApplicationRole applicationRole { get; set; }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var images = ProcessUploadedFile(Input.nomeescritorio);
            if (images.Equals("Vazio"))
            {
                Random b = new Random();
                ModelState.AddModelError("Input.nomeescritorio", "O Nome do escritorio é invalido. tente outro ex: Adv-" + Input.nomeescritorio + b.Next(9999));
             
            }
            if (ModelState.IsValid)
            {
                //criar a empresa
                Empresa_tb em = null;
                try
                {
                     em = new Empresa_tb();
                   
                   
                    em.NomeEmpresa = Input.nomeescritorio;
                    em.LogoTipoEmpresa = images;
                    db.Empresa_Tbs.Add(em);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
               
                //depos relacionar com o usario
                var user = new ApplicationUser
                {
                    Nome = Input.nome,
                    apelido = Input.apelido,
                    UserName = Input.Email,
                    Email = Input.Email,
                    idempresa = em.Ids,
                   // SecurityStamp = Guid.NewGuid()

                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (!await roleManager.RoleExistsAsync("Administrador"))
                {
                    await roleManager.CreateAsync(new ApplicationRole("Administrador", "Administrador", DateTime.Now));
                    await roleManager.CreateAsync(new ApplicationRole("Advogado", "Advogado", DateTime.Now));
                    await roleManager.CreateAsync(new ApplicationRole("Assistente", "Assistente", DateTime.Now));
                    await roleManager.CreateAsync(new ApplicationRole("Admintarefas", "Admintarefas", DateTime.Now));

                    RecurringJob.AddOrUpdate(() => Envianotificacao(), Cron.Daily(7,30)) ; 
                    RecurringJob.AddOrUpdate(() => EnvianotificacaoActividades(), Cron.Daily(8)) ; 
                }
                await _userManager.AddToRoleAsync(user, "Advogado");

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
                    var message = new Message( Input.Email  , "Confirm your email", $"Please confirm your account by < a href = '{HtmlEncoder.Default.Encode(callbackUrl)}' > clicking here </ a >.");
                await _emailSender.SendEmail(message);
                    ////await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    ////    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

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
            

                string fullPath = Path.Combine(_env.WebRootPath, "Escritorios/" + nomedaempresa);
                if (!Directory.Exists(fullPath))
                {
                    _logger.LogInformation("criar directorio para a empresa em particula." + nomedaempresa);
                    Directory.CreateDirectory(fullPath);
                    string uploadsFolder = fullPath;
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + Input.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Input.Photo.CopyTo(fileStream);
                    }
                }
                else
                {
                    return "Vazio";
                }
              
            }

            return uniqueFileName;
        }
    }
}