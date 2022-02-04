using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeblawyersBox.Pages.EmaiSservice;
using static WeblawyersBox.Email.EnviarEmailCliente;

namespace WeblawyersBox.Email
{
    public class EnviarEmailCliente : IEmailSenders
    {
      
        private readonly EmailConfiguration _emailConfigurationuration;

        public EmailOpions emailOpions { get; set; }
        public EnviarEmailCliente(EmailConfiguration emailConfiguration)
        {
            this._emailConfigurationuration = emailConfiguration;
        }
        
      
      

       
        public interface IEmailSenders
        {
            Task SendEmail(Message message);
        }

     
        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfigurationuration.UserName,_emailConfigurationuration.From));
            emailMessage.To.Add(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }

        private async Task Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                
                try
                {
                    client.Connect(_emailConfigurationuration.SmtpServer, _emailConfigurationuration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfigurationuration.UserName, _emailConfigurationuration.Password);

                    client.Send(mailMessage);
                }
                catch (System.Exception ex)
                {
                    //log an error message or throw an exception or both.
                    throw new System.Exception (ex.Message);
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        Task IEmailSenders.SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            return Send(emailMessage);
        }
    }
   
}
