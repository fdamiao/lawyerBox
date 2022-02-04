using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeblawyersBox.servicos;

namespace WeblawyersBox.Models
{
    public class EstatusProcess:Audit
        
    {
     
        public estadoss status { get; set; }
        [Required]
        [StringLength(250)]
        public string descricao { get; set; }
        [Required]
      
        [Display(Name = "Processo")]
        [ValidarGuid]
        public string Idprocesso { get; set; }
        public virtual Processo_tb Processo_Tb  { get; set; }
      
    }
}
