using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeblawyersBox.Data;
using WeblawyersBox.Models;

namespace WeblawyersBox.ViewComponete
{
    public class logocomponetViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment ihostingEnvironment;

        public logocomponetViewComponent(WeblawyersBox.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment ihostingEnvironment)
        {
            this.context = context;
            this.userManager = userManager;
            this.ihostingEnvironment = ihostingEnvironment;
        }
        public async Task<string> InvokeAsync()
        {
            Empresa_tb em = null;
            try
            {
                var user = await userManager.FindByEmailAsync(User.Identity.Name);

                // var user = (ApplicationUser)await userManager.GetUserAsync(User.Identity.Name);
                 em = context.Empresa_Tbs.Where(b => b.Ids == user.idempresa).FirstOrDefault();
                string fullPath = Path.Combine(ihostingEnvironment.WebRootPath, em.NomeEmpresa + "/" + em.LogoTipoEmpresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
            return "bog";
        }

    }
}
