using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.Models.ViewModel
{
    public class honorarisoVieModels:Audit
    {
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [DataType(DataType.Currency)]
        public decimal valor { get; set; }
        [Required]
        [StringLength(250)]
        public string descricaoDovalor { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string datarecebimento { get; set; }
        public IFormFile comprovativo { get; set; }
        public tipofacturacao tipofacturacao { get; set; }
        public despesaestatus Despesaestatus { get; set; }
        public string idprocesso { get; set; }
     
        public List<IFormFile> FormFiles { get; set; } // convert to list
    }
}
