using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.Models
{
    public class TpProcesso:Audit
    {
        [StringLength(50)]
        public string rubrica { get; set; }
        [StringLength(150)]
        public string descricao { get; set; }
        //public virtual ICollection< Processo_tb> Processo_Tb { get; set; }
      
    }
}
