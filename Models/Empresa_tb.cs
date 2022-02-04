using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.servicos;

namespace WeblawyersBox.Models
{
    public partial class Empresa_tb
    {
        public Empresa_tb()
        {
           
           Processo_Tb = new HashSet<Processo_tb>();
            this.Ids = Guid.NewGuid().ToString();
            this.datacreat = DateTime.Now;
        }
       
        [Key]
        public string Ids { get; set; }
        [Required]
        [StringLength(150)]
       
        public string NomeEmpresa { get; set; }
        [StringLength(50)]
        public string ContactoTelefone { get; set; }
        [StringLength(100)]
        [EmailAddress]
        public string EmailEmpresa { get; set; }
        [StringLength(100)]
        public string LocalizacaoEmpresa { get; set; }
        public string LogoTipoEmpresa { get; set; }
        [Column(TypeName = "date")]
        public DateTime? datefecho { get; set; }
        [StringLength(50)]
        public string estado { get; set; }
        public string caminho { get; set; }
        [DataType(DataType.Date)]
        public DateTimeOffset datacreat { get; set; }
      
       public virtual ICollection<Processo_tb> Processo_Tb { get; set; }
        // public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}
