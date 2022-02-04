using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.servicos
{
    public class ValidarDataactual: ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime dt = (DateTime)value;
        if (dt <= DateTime.UtcNow)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "A data deve ser  <= a hoje");
    }

}
    
    }

