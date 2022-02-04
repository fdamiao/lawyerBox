using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.servicos;

namespace WeblawyersBox.Models
{
    public partial class Processo_tb : Audit
    {
        public Processo_tb()
        {
            Audiencia_Tabs = new HashSet<Audiencia_tab>();
            Documentos_Processos_tb = new HashSet<Documentos_Processos_tb>();
            Pessoas_Envolvidas_tb = new HashSet<Pessoas_Envolvidas_tb>();
            DetalhesdeActividades = new HashSet<Intrevistas>();
            Estados = estadoss.Activo;
            Valorcondenacao = 0;
            ValordeCausa = 0;
            NProcesso = "caso-" + Fisico;
            TituloProcesso = "Nada";
            Iduser = "N/A";
            
        }



        [StringLength(50)]
        [Required]
        [Display(Name = "N:")]
        public string NProcesso { get; set; }
        [StringLength(250)]
        public string Observacao { get; set; }
        [StringLength(250)]
        public string Objecto { get; set; }
        [StringLength(200)]
        [Required]
        [Display(Name = "Titulo")]
        public string TituloProcesso { get; set; }

        //[Column(TypeName = "date")]
        //[Display(Name = "Notificacao")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime? DataNotificacao { get; set; }
     

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Valor")]
        public decimal? ValordeCausa { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Valor da condenacao")]
        public decimal? Valorcondenacao { get; set; }
        //[Column(TypeName = "date")]
        //public DateTime? DataDistribuicao { get; set; }
        [StringLength(50)]
        [Display(Name = "Pasta fisica")]
        public string Fisico { get; set; }
        public bool Estado { get; set; }
        public estadoss Estados { get; set; }
        [ValidarGuid]
        [Display(Name = "Cliente")]
        public string Idcliente { get; set; }
        public virtual Cliente_tb Cliente_Tb { get; set; }
        public string idempresas { get; set; }
        public virtual Empresa_tb Empresa_Tb { get; set; }
        public instacia instacia { get; set; }
        public locais Categorias { get; set; }
        public tipo tipo { get; set; }
        public virtual ICollection<Audiencia_tab> Audiencia_Tabs { get; set; }
        public virtual ICollection<Documentos_Processos_tb> Documentos_Processos_tb { get; set; }
        public virtual ICollection<Pessoas_Envolvidas_tb> Pessoas_Envolvidas_tb { get; set; }
        public virtual ICollection<Intrevistas> DetalhesdeActividades { get; set; }
        public virtual ICollection<FacturacaoTbs> FacturacaoTbs { get; set; }
        public virtual ICollection<CobrancaTB> CobrancaTBs { get; set; }






    }
    public enum estadoss
    {
        Activo,
        Pausado,
        Cancelado,
        Concluido
    }
    public enum tipo { 
    Caso,Processo
    }
    public enum instacia
    {
        [Display(Name = "N/A")]
        NA,
        [Display(Name ="1 Grau")]
        Igrau,
        [Display(Name = "2 Grau")]
        IIgrau,
        [Display(Name = "Instacia superor")]
        superior,
        [Display(Name = "Instacia suprema")]
        Supremo,
      
    }
    public enum locais
    {
        [Display(Name = "Tribunal Distrital")]
        Destritais,
        [Display(Name = "Tribunal provincial")]
        Provincial,
        [Display(Name = "Tribunal Supremo de Recurso")]
        supremo_recuros,
        [Display(Name = "Tribunal Supremo")]
        TTribunal_Supremo,
       
    }

}
