using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Facturas
{
    public class CobrancasModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService notyf;

        public CobrancasModel(ApplicationDbContext context, INotyfService notyf)
        {
            this._context = context;
            this.notyf = notyf;
        }

        public IList<CobrancaTB> CobrancaTB { get; set; } = new List<CobrancaTB>();
        public async Task OnGetAsync()
        {
           
           // CobrancaTB = await _context.CobrancaTBs.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(List<CobrancaTB> cobrancaTBs)
        {
            
           
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //var cobra = new CobrancaTB();
            //foreach (var item in cobrancaTBs)
            //{
            //    cobra = new CobrancaTB();
            //    cobra.descricao = item.descricao;
            //    cobra.Iduser = item.Iduser;
            //    cobra.idprocesso = item.idprocesso;
            //    cobra.precoUnit = item.precoUnit;
            //    cobra.precTotal =decimal.Parse( item.precoUnit.ToString())*decimal.Parse( item.Qty.ToString());
            //    cobra.Qty = item.Qty;

            //}
            notyf.Success("acionado com sucesso");


          
            await _context.SaveChangesAsync();
            notyf.Success("processo criado com sucesso");
            return RedirectToPage("/Processo/Details");
        }
        }
}