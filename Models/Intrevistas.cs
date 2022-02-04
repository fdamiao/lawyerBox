
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WeblawyersBox.servicos;

namespace WeblawyersBox.Models
{
    public class Intrevistas:Audit
    {
        
        [Required]
      
        [Display(Name = "Processo")]
        [ValidarGuid]
        public string idprocesso { get; set; }
        public virtual Processo_tb Processo_Tb { get; set; }
       
       
        [Required]
        [Display(Name = "Descricao")]
        [DataType(DataType.MultilineText)]
        [StringLength(1000)]
        public string DescricaoActividade { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [ValidarDataactual]
        public DateTime dataConverca { get; set; }
        public string idempresa { get; set; }


    }
}
