using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.Models
{
    public class FacturacaoTbs:Audit
    {
       [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal valor { get; set; }
        [Required]
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descricao")]
        public string descricaoDovalor { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Data")]
        public string datarecebimento { get; set; }
        public string comprovativo { get; set; }
        public tipofacturacao tipofacturacao { get; set; }
        [Display(Name = "Estatus")]
        public despesaestatus Despesaestatus { get; set; }
        public string idprocesso { get; set; }
        public virtual Processo_tb Processo_Tb { get; set; }
        public string idempresa { get; set; }
        // public IFormFile Photo { get; set; }
    }
    public enum tipofacturacao
    {
        Despesas,
        Honorarios
    }
    public enum despesaestatus
    {
        Arealizar,
        Realizado,
        
    }
}
