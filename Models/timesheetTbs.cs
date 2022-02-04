using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WeblawyersBox.servicos;

namespace WeblawyersBox.Models
{
    public class timesheetTbs:Audit
    {
        [Required]
      
        [Display(Name = "Processo")]
        [ValidarGuid]
        public string idprocesso { get; set; }
        public virtual Processo_tb Processo_Tb { get; set; }
        [Display(Name = "Data")]
        [ValidarDataactual]// adata dee ser <=a data actua;
        public DateTime datarealisada { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Horas")]
        public decimal horasrealizadas { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Descricao")]
        [DataType(DataType.MultilineText)]
        public string descricadashoras { get; set; }
        public cargo cargo { get; set; }
        public string idempresa { get; set; }

    }
    public enum cargo { 
    Advogado,
    Estagiario,
    Tecnico

    }
}
