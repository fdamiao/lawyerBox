using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeblawyersBox.servicos;
using Microsoft.AspNetCore.Identity;

namespace WeblawyersBox.Models
{
    public class Audit
    {
        public UserManager<ApplicationUser> UserManager ;

       [Key]
       [Display(Name ="Codigo")]
        public string Ids { get; set; }
        [DataType(DataType.Date)]
        public DateTimeOffset datacreat { get; set; }
        [StringLength(180)]
       // [Required(ErrorMessage = "O Usuario  é obrigatorio")]
        [Display(Name = "usuario")]
        public string Iduser { get; set; }
        [Display(Name = "Responsavel")]
        public string responsavel { get; set; }
       

        //private static ClaimsPrincipalExtensions User = null;
        public Audit()
        {

            this.Ids = Guid.NewGuid().ToString() ;
           this.datacreat = DateTime.UtcNow;
                responsavel = "N/A";
            
           
           
           
          
          
        }
     public static   bool isguid(string codigo)
        {
            Guid b;
            return Guid.TryParse(codigo,out b);
        }
    }
}
