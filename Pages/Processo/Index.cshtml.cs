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
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Processo
{
    public class IndexModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }
        [BindProperty]
        public string idcli { get; set; }
     private string Getcliente()
        {
            var idclis = idcli;
            return idclis;
        }
        public  PartialViewResult OnGetNovoprocessoparcial() {
            var bog = Getcliente();
          
           

            ViewData["idcliente"] = idcli;
            return new PartialViewResult
            {
                ViewName = "_NovoprocessoParcial",
                ViewData = new ViewDataDictionary<Processo_tb>(ViewData, new Processo_tb { }),
               

            };
        }
        public async Task<PartialViewResult> OnPostNovoprocessoparcial(Processo_tb model)
        {
            var user = await UserManager.GetUserAsync(User);

           // model.Idcliente = id;
            model.Iduser = user.Id.ToString();
            if (ModelState.IsValid)
            {
                _context.Processo_Tbs.Add(model);
                await _context.SaveChangesAsync();

            }
          

            return new PartialViewResult
            {
                ViewName = "_NovoprocessoParcial",
                ViewData = new ViewDataDictionary<Processo_tb>(ViewData, model)
            };

        }

        public IList<Processo_tb> Processo_tb { get;set; } 
        public IList<Processo_tb> Casos { get;set; }
        [BindProperty]
        public Cliente_tb Cliente_Tbs { get; set; }
     
        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<IActionResult> OnGetAsync( string id)
        {
            if (id == null)
            {
               
                return RedirectToPage("/erro/Erro404");
            }
           
            if (isguid(id))
            {
 Cliente_Tbs = await _context.Cliente_Tbs.FirstOrDefaultAsync(m => m.Ids == id);

            if (Cliente_Tbs == null)
            {
                return NotFound();
            }
            try
            {
                ViewData["TotalHprocesso"] = await _context.Processo_Tbs.Where(v => v.Idcliente == id && v.tipo == tipo.Processo).CountAsync();
                ViewData["Totaldcaso"] = await _context.Processo_Tbs.Where(v => v.Idcliente == id && v.tipo == tipo.Caso).CountAsync();

                Processo_tb = await _context.Processo_Tbs.Where(p => p.Idcliente == id && p.tipo == tipo.Processo).ToListAsync();
                Casos = await _context.Processo_Tbs.Where(p => p.Idcliente == id && p.tipo == tipo.Caso).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            }
            else
            {
                return NotFound();
            }
            // ViewData["idTpprocesso"] = new SelectList(_context.TpProcessos, "idTpprocesso", "descricao");
           
          
            return Page();
           // 
        }
        static bool isguid(string codigo)
        {
            return Guid.TryParse(codigo, out Guid b);
        }
    }
}
