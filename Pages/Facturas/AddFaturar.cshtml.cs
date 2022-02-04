using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.Pages.Facturas
{
    public class AddFaturarModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public AddFaturarModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet( string id)
        {
            if (id==null)
            {
                return NotFound();
            }
            CobrancaTB = _context.CobrancaTBs.Where(v => v.idprocesso == id).FirstOrDefault();
            ListCobrancaTB = _context.DetalhesCobrancas.Where(v=>v.CobrancaTB.idprocesso==id).ToList();
            return Page();
        }

        [BindProperty]
        public CobrancaTB CobrancaTB { get; set; }
        public DetalhesCobranca detalhesCobranca { get; set; }
        public List< DetalhesCobranca> ListCobrancaTB { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
          var  Cobran = _context.CobrancaTBs.Where(v => v.idprocesso == detalhesCobranca.idprocesso).FirstOrDefault();
            CobrancaTB bb = null;
            if (Cobran==null)
            {
                 bb = new CobrancaTB();
                bb.idprocesso = detalhesCobranca.idprocesso;
                bb.Iduser = detalhesCobranca.iduser;
                bb.numero = new Random().Next(999999);
                bb.estadoss = estadoss.Activo;
                _context.CobrancaTBs.Add(bb);
                detalhesCobranca.idcobranca = bb.Ids.ToString();


            }
            else
            detalhesCobranca.idcobranca = Cobran.Ids.ToString();

            detalhesCobranca.precTotal = decimal.Parse(detalhesCobranca.precoUnit.ToString()) * decimal.Parse(detalhesCobranca.Qty.ToString());

            _context.DetalhesCobrancas.Add(detalhesCobranca);
            await _context.SaveChangesAsync();

            return RedirectToPage("./AddFaturar");
        }
    }
}
