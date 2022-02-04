using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WeblawyersBox.servicos
{
    public class ServicoUtilisador : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;

        public ServicoUtilisador(IHttpContextAccessor httpContext)
        {
            this._httpContext = httpContext;
        }

        public string GetEmpresaId()
        {
           throw new NotImplementedException();
        }

        public string GetUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public bool IsAuthenticated()
        {
            return _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
