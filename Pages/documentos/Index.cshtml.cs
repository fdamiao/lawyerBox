using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Data;
using WeblawyersBox.Models;
using WeblawyersBox.servicos;

namespace WeblawyersBox.Pages.documentos
{
    public class IndexModel : PageModel
    {
        private readonly WeblawyersBox.Data.ApplicationDbContext _context;

        public IndexModel(WeblawyersBox.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Documentos_Processos_tb> documentos_Processos_s { get; set; }
        public dadosdePaginacao dadosdePaginacao { get; set; }
        public async Task OnGetAsync(int PageNum = 1)
        {

            documentos_Processos_s = _context.Documentos_Processos_Tbs.OrderBy(m => m.Ids).ToList<Documentos_Processos_tb>();
            StringBuilder QParam = new StringBuilder();
            if (PageNum != 0)
            {
                QParam.Append($"/Index?PageNum=-");

            }
            if (documentos_Processos_s.Count > 0)
            {
              
                documentos_Processos_s = documentos_Processos_s.Skip((PageNum - 1) * 10)
               .Take(10).ToList();

                documentos_Processos_s = await _context.Documentos_Processos_Tbs
                .Include(d => d.idProcessoNavigation).ToListAsync();


            }
        }
    }
}
    

