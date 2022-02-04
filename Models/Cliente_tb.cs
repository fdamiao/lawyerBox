using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using WeblawyersBox.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeblawyersBox.Models
{
    public partial class Cliente_tb:Audit
    {
       

        
    
        //private ApplicationUser User;
        public Cliente_tb()
        {


           Processo_tb = new HashSet<Processo_tb>();
            empresa = "N/A";
            

        }
      
        public string buscarnomes() => Nome = Nome + " " + apelido;
        //[Key]
        //public string IdCliente { get; set; }
        [Required]
        [StringLength(150)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",ErrorMessage = "Carateres nao suportados")]
        [DisplayName("Nome ")]
        public string Nome { get; set; }
        [StringLength(50)]
        public string apelido { get; set; }
        [Required]
        [StringLength(50)]
        public string Ndocumento { get; set; }
        [Required]
        [StringLength(50)]
        public string Naturalidade { get; set; }
        [Required]
        [StringLength(50)]
        public string Contacto { get; set; }
        [Required]
        [StringLength(50)]
        public string Morada { get; set; }
        [StringLength(50)]
        [Required]
        [DisplayName("Tipo de cliente")]
        public string TipoPessoa { get; set; }
        //[StringLength(50)]
        //[DisplayName("Estado civil")]
        //public string EstadoCivil { get; set; }
        [StringLength(50)]
        public string profissao { get; set; }
        public string empresa { get; set; }
        public string nacionalidade { get; set; }
        public string idempresa { get; set; }
        [EmailAddress]
        public string email { get; set; }


        public virtual ICollection<Processo_tb> Processo_tb { get; set; }
    }
}
