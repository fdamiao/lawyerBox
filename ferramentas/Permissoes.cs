using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.ferramentas
{
    public class Permissoes
    {
        public static List<string> GerarpermissoeporModlu(string modulo)
        {
            return new List<string>()
            {
            $"Permissoes.{modulo}.Create",
            $"Permissoes.{modulo}.View",
            $"Permissoes.{modulo}.Edit",
            $"Permissoes.{modulo}.Delete",
            };
        }
    }
    public static class clientes
    {
       // public const string View = "permissoses.clientes.View"; { get; set; }
    }
}
