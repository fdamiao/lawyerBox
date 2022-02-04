using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.Models
{
    public class pagamentoLicenca:Audit
    {
        public pagamentoLicenca()
        {
            datapfim = datapagamento.AddMonths(meses);
        }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal valorpago { get; set; }
        public int meses { get; set; }
      
        public DateTime datapagamento { get; set; }
        public DateTime datapfim { get; set; }
        public string comentarios { get; set; }
        public string idempresa { get; set; }
        public estadoss estadoss { get; set; }
        public virtual Empresa_tb Empresa_Tb { get; set; }
        public string idlicensa { get; set; }
        public virtual licensastbs licensastbs { get; set; }
    }
}
