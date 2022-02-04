using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.Models
{
    public class ResponsavesTb:Audit
    {
        public string idprocesso { get; set; }
        public virtual  Processo_tb   Processo_Tb { get; set; }
    }
}
