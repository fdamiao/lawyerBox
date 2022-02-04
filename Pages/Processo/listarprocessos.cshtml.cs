using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeblawyersBox.Data;
using WeblawyersBox.Models;
using WeblawyersBox.Models.ViewModel;

namespace WeblawyersBox.Pages.Processo
{
    public class listarprocessosModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public listarprocessosModel(ILogger<IndexModel> logger,WeblawyersBox.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.logger = logger;
            _context = context;
            this.userManager = userManager;
           // _context.Configuration.LazyLoadingEnabled = false;
        }

       // public IList<Processo_tb> Processo_tb { get;set; }
        public IList<Cliente_tb> cliente_Tbs { get;set; }
        public IList<TpProcesso> tpProcessos { get;set; }
       
    
        public Cliente_tb Cliente_Tbs { get; set; }
       
        public List<TpProcesso> stpprocessos { get; set; }
        //Para tratar as informações de clientes e pedidos
       public List<ClietprocessoViewModel> Processo_tb = new List<ClietprocessoViewModel>();
        async Task listadeprocesso(string idempresa)
        {
            var listaClientes =await (from Cli in _context.Cliente_Tbs
                                 join Ped in _context.Processo_Tbs on Cli.Ids equals Ped.Idcliente
                                 where Cli.idempresa==idempresa
                                      select new
                                      {
                                          Cli.Nome,
                                          Cli.apelido,
                                          Ped.datacreat,
                                          Ped.tipo,
                                          Ped.TituloProcesso,
                                          Ped.Observacao,
                                          Ped.Objecto,
                                          Ped.instacia,
                                          Ped.Estados,
                                          Ped.Ids,
                                      }).AsNoTracking().ToListAsync();

            foreach (var item in listaClientes)
            {
                ClietprocessoViewModel Cli = new ClietprocessoViewModel(); //ViewModel
                Cli.Nome = item.Nome;
                Cli.apelido = item.apelido;
                Cli.datacreat = item.datacreat;
                Cli.tipo = item.tipo.ToString();
                Cli.TituloProcesso = item.TituloProcesso ;
                Cli.Observacao = item.Observacao;
                Cli.Objecto = item.Objecto;
                Cli.instacia = item.instacia.ToString();
                Cli.Estados = item.Estados.ToString();
                Cli.Ids = item.Ids.ToString();
                Processo_tb.Add(Cli);
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await userManager.GetUserAsync(User);

         await   listadeprocesso(user.idempresa);
                // Processo_tb = await _context.Processo_Tbs.Where(x => x.idempresas == user.idempresa )
                //.AsNoTracking()
                //.ToListAsync();
            

            //////Order will be null if the left join is nullawait 
            //tpProcessos = await _context.TpProcessos.ToListAsync();
            //cliente_Tbs = await _context.Cliente_Tbs.ToListAsync();
           
            

         
            //stpprocessos = await _context.TpProcessos.ToListAsync();
           
            return Page();
            // ViewData["processo"] = query;
        }
    }
}
