using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.Models
{
    public class licensastbs
    {
        public licensastbs()
        {
            idlices = Guid.NewGuid().ToString();
            datacriacao = DateTime.Now;
        }
        double valorAnual()
        {
            return (preco * 12) - preco;
        }
        double valorsemestral()
        {
            return (preco * 6) - (preco/2);
        }
        [Key]
        [Display(Name = "Codigo")]
        public string idlices { get; set; }
        [Display(Name = "Licença")]
        public tipodelicenca tipodelicass { get; set; }
        [Display(Name = "n Usuario")]
        public int usuarios { get; set; }
        public bool honorarios { get; set; }
        public bool timeshe { get; set; }
        public bool despesa { get; set; }
        [Display(Name = "espaco ")]
        public long GB { get; set; }
        [Display(Name = "Nprocesso")]
        public int processo { get; set; }
        public DateTime datacriacao { get; set; }
        [Required]
        public double preco { get; set; }
        public string descricao { get; set; }

    }
    public enum tipodelicenca { 
    stanadard,
    profissional,
    Busines

    }
}
