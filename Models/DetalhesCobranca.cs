using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.Models
{
    public class DetalhesCobranca
    {
        public DetalhesCobranca()
        {//CobrancaTB
            Iddetalhes = Guid.NewGuid().ToString();
        }
        [Key]
        public string Iddetalhes { get; set; }
        [Required]
        [Display(Name = "Descricao")]
        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string descricao { get; set; }
        public double Qty { get; set; } = 1;
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal precoUnit { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal precTotal { get; set; }
        public string idcobranca { get; set; }
        public virtual CobrancaTB CobrancaTB { get; set; }
        [DataType(DataType.Date)]
        public DateTime dataregistro { get; set; }
        public string iduser { get; set; }
        public string idprocesso { get; set; }

    }
}
