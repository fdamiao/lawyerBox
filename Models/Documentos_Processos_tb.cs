using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.servicos;

namespace WeblawyersBox.Models
{
    public partial class Documentos_Processos_tb:Audit
    {


       
        [StringLength(350)]
        public string nomeDoc { get; set; }
        [StringLength(50)]
     
        public string ContentType { get; set; }
        [ValidarGuid]
        public string idempresa { get; set; }

        [StringLength(500)]
        public string NomeFicheiro { get; set; }
        [Required]
      
        [Display(Name = "Processo")]
        [ValidarGuid]
        public String idProcesso { get; set; }
        [ForeignKey(nameof(idProcesso))]
        [InverseProperty(nameof(Processo_tb.Documentos_Processos_tb))]
        public virtual Processo_tb idProcessoNavigation { get; set; }
    }
}
