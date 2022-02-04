using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeblawyersBox.Data;
using WeblawyersBox.Models;
using static WeblawyersBox.Email.EnviarEmailCliente;

namespace WeblawyersBox.Pages.EmaiSservice
{
    public class Enviarnotfica : IEnviarJobes
        
        
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration configuration;
        private readonly IEmailSenders _emailSender;
        private readonly ILogger<Enviarnotfica> logger;
        public Enviarnotfica()
        {
          //  Enviarnotfica(ApplicationDbContext applicationDbContext, IConfiguration configuration, IEmailSenders emailSender, ILogger < Enviarnotfica > logger)
        }
        public Enviarnotfica(ApplicationDbContext applicationDbContext, IConfiguration configuration, IEmailSenders emailSender, ILogger<Enviarnotfica> logger)
        {
            this._applicationDbContext = applicationDbContext;
            this.configuration = configuration;
       
            this.logger = logger;
            this._emailSender = emailSender;
           
          
        }
      
        public void envianotificacao()
        {
          //  applicationDbContext = new ApplicationDbContext();
         //   var bog =new Enviarnotfica(_applicationDbContext, configuration, _emailSender, logger);
           //agenda
           //var Audiencia_tabs = _applicationDbContext.Audiencia_Tabs.Where(x => x.Estado == estado.Agendado)
           //      .Include(a => a.Processo_Tb).AsNoTracking().ToList();
           // if (Audiencia_tabs != null)
           // {


           //     foreach (var item in Audiencia_tabs)
           //     {
           //         //alerta par 2 dias
           //         if (item.datacreat.Subtract(DateTime.Now).TotalDays >= -2)
           //         {
           //             //'envir notificacao

           //             var message = new Message(item.responsavel, "Agenda marcada", $"Temos agendado para o dia : {item.DataMarcada}, fazer {item.descricaevento} , No {item.LocaldaAudiencia}");
           //             _emailSender.SendEmail(message);
           //             logger.LogInformation("email eniado com sucesso para" + message.To);
           //         }
           //     }
           // }
           // else
           // {
           //     logger.LogInformation("nada agendado para os proximos dias");
           // }
        }
    }
}
