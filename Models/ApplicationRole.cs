using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeblawyersBox.Data;

namespace WeblawyersBox.Models
{
    public class ApplicationRole: IdentityRole<Guid>
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName)
        {

        }

        public ApplicationRole(string roleName, string description, DateTime creationDate) : base(roleName)
        {
            this.descricao = description;
            this.CreationDate = creationDate;
        }

        public string descricao { get; set; }
        public DateTime CreationDate { get; set; }
       
       // public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
