using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.Models
{
    public class CobrancaTB:Audit
    {
        [Required]
        public int numero { get; set; }
        public estadoss estadoss { get; set; }
        public double subtotal { get; set; }
        public double Iva { get; set; }
        public double Totalgeral { get; set; }
        public double desconto { get; set; }
        public string consideracoes { get; set; }

        public string idprocesso { get; set; }
        public virtual Processo_tb Processo_Tb { get; set; }
        public string idempresa { get; set; }
    }
}
