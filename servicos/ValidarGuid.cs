using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.servicos
{
    public class ValidarGuid : ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
            string bog = (string)value;
            if (bog != null)
            {
               

                var b = Guid.Parse(bog.ToString());
                if (isguid(b.ToString()))
                {
                    return ValidationResult.Success;
                }

            }
            else
            {
                return ValidationResult.Success;
            }
        return new ValidationResult(ErrorMessage ?? "Codigogo incorrecto");
           static bool isguid(string codigo)
            {
                return Guid.TryParse(codigo, out Guid b);
            }
        }
    }


}
    
    

