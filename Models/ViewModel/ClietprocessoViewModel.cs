using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.Models.ViewModel
{
    public class ClietprocessoViewModel:Audit
    {
        public string buscarnome()
        {
            return Nome = Nome + " " + apelido;
        }
        public string idprocesso { get; set; }
        public string Nome { get; set; }
    
        public string apelido { get; set; }
        //processo

        [Display(Name = "N:")]
        public string NProcesso { get; set; }
     
        public string Observacao { get; set; }
   
        public string Objecto { get; set; }
    
        [Display(Name = "Titulo")]
        public string TituloProcesso { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Notificacao")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNotificacao { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Valor")]
        public decimal? ValordeCausa { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Valor da condenacao")]
        public decimal? Valorcondenacao { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DataDistribuicao { get; set; }
 
        public string Fisico { get; set; }
        public bool Estado { get; set; }
        public string Estados { get; set; }
        public string idempresas { get; set; }
        public string instacia { get; set; }
        public string tipo { get; set; }

    }
}
