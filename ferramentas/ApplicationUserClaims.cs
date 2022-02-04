
    using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WeblawyersBox.Models;

namespace WeblawyersBox.ferramentas
{
        public class ApplicationUserClaims : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
        {
            public ApplicationUserClaims(UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
                : base(userManager, roleManager, options)
            {
            }

            protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
            {
                var identity = await base.GenerateClaimsAsync(user);
                identity.AddClaim(new Claim("Nome", user.Nome ?? ""));
                identity.AddClaim(new Claim("Apelido", user.apelido ?? ""));
               
                return identity;
            }
        }
    }

