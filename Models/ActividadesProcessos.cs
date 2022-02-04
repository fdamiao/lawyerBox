using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WeblawyersBox.servicos;

namespace WeblawyersBox.Models
{
    public class ActividadesProcessos:Audit
    {
        public ActividadesProcessos()
        {
            prioridades = prioridade.Baixa;
            status = estado.Agendado;
            cores = "#6F1E51";
        }
      //  [Required]
        [StringLength(180)]
        [Display(Name = "Processo")]
        [ValidarGuid]
        public string idprocesso { get; set; }
        public virtual Processo_tb Processo_Tb { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        [Display(Name = "Descricao da acividade")]
        public string Descricaoactividades { get; set; }
        [DataType(DataType.Date)]
        [ValidarDataaEventos]
        public DateTime data { get; set; }
        [Display(Name = "Prioridade")]
        public prioridade prioridades { get; set; }
        [Display(Name = "Activo ?")]
        public estado status { get; set; }
      
        public string cores { get; set; }
        public string idempresa { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime datadarealizacao { get; set; }

    }
    
}
