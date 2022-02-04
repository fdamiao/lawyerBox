using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.servicos;

namespace WeblawyersBox.Models
{
    public partial class Pessoas_Envolvidas_tb:Audit
    {
   
       
        [Display(Name = "Processo")]
        [ValidarGuid]
        public string idProcesso { get; set; }
        [StringLength(150)]
        [Required]
        public string NomePessoa { get; set; }
        [Required]
        [StringLength(50)]
        public string Posicao { get; set; }
        [StringLength(50)]
        public string Contacto { get; set; }

        [ForeignKey(nameof(idProcesso))]
        [InverseProperty(nameof(Processo_tb.Pessoas_Envolvidas_tb))]
        public virtual Processo_tb idProcessoNavigation { get; set; }
    }
}
