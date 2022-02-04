using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using WeblawyersBox.Models;
using WeblawyersBox.Pages.EmaiSservice;
using static WeblawyersBox.Email.EnviarEmailCliente;

namespace WeblawyersBox.Pages.Autenticar
{
    [AllowAnonymous]
    public class RecoperarSenhaModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSenders _emailSender;

        public RecoperarSenhaModel(UserManager<ApplicationUser> userManager, IEmailSenders emailSender)
        {
            this._userManager = userManager;
            this._emailSender = emailSender;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
              //      return RedirectToPage("/Pages/Account/ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);
               
               
               // _logger.LogInformation("2-email eniado com sucesso para" + message.To);
                var message = new Message(
                    Input.Email,
                    "Recoperar palavra pass",
                    $"recopere sua palavra pass <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Clicando aqui</a>.");
                await _emailSender.SendEmail(message);
                return RedirectToPage("./ValidarEmail");
            }

            return Page();
        }
    }
}