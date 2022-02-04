using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeblawyersBox.Data;

namespace WeblawyersBox.Models
{
    public class ApplicationUser: IdentityUser<Guid>
    {
       
        [PersonalData]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Carateres nao suportados")]
        public string Nome { get; set; }
        [PersonalData]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Carateres nao suportados")]
        public string apelido { get; set; }
        public string idempresa { get; set; }
        public virtual Empresa_tb empresa_Tb { get; set; }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
      //  public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
