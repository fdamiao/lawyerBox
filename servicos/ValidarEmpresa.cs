using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.servicos
{
    public class ValidarEmpresa : ValidationAttribute {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ValidarEmpresa(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext )
    {
            string bog = (string)value;

            string fullPath = Path.Combine(webHostEnvironment.WebRootPath, "Escritorios/" + bog);
            if (!Directory.Exists(fullPath))
            {
                //se o diretorio nao exite vai deixarpassar
                return ValidationResult.Success;
            }
            Random b = new Random();
           
        return new ValidationResult(ErrorMessage ?? "Nome do ecritorio invalido tente outro ex Adv-"+bog+b.Next(9999));
         
        }
    }


}
    
    

