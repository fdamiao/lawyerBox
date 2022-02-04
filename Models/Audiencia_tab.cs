using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.servicos;

namespace WeblawyersBox.Models
{//eneventos
    public partial class Audiencia_tab : Audit
    {
        public Audiencia_tab()
        {
            dataCreataud = DateTime.Now;
            Estado = estado.Agendado;
            cores = "#6F1E51";
        }
        [DataType(DataType.DateTime)]
        [ValidarDataaEventos]
        [Display(Name ="Data")]
        public DateTime DataMarcada { get; set; }
        [ValidarDataaEventos]
        [DataType(DataType.DateTime)]
        public DateTime Datatermino { get; set; }
        [Required]
        public estado Estado { get; set; }
        [ValidarGuid]
        public string idProcesso { get; set; }
        [Required]
        [StringLength(150)]
        public string evento { get; set; }
        [DataType(DataType.Date)]
        public DateTime dataCreataud { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name ="Local")]
        public string LocaldaAudiencia { get; set; }
        public prioridade prioridade { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        [Display(Name = "Descricao do evento")]
        public string descricaevento { get; set; }
        public string cores { get; set; }

        [ForeignKey(nameof(idProcesso))]
        public virtual Processo_tb Processo_Tb { get; set; }
        public string idempresa { get; set; }

    }
    public enum prioridade
    {
        Baixa,
        Media,
        Alta,
        Critica
    }
    public enum estado
    {
        Agendado,
        Concluido,
        Cancelado
    }
}