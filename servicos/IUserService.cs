using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.servicos
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
        string GetEmpresaId();
    }
}

