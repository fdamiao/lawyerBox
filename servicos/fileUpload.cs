using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.servicos
{
    public class fileUpload
    {

        [Display(Name = "Documentos")]
        [MaxLength(2 * 1024 * 1024)]
        [Required(ErrorMessage = "Escolha o documento")]
       /// FileExtensions(Extensions = "jpg,gif,png,PDF,XLS,XLSX,DOC,DOCX", ErrorMessage = "Tipo de documento nao aceite")]
        public List<IFormFile> FormFiles { get; set; } // convert to list
        public string SuccessMessage { get; set; } 
    }
    public class fileHonorarios
    {
        [Display(Name = "Documentos")]
        [MaxLength(2 * 1024 * 1024)]
      
        /// FileExtensions(Extensions = "jpg,gif,png,PDF,XLS,XLSX,DOC,DOCX", ErrorMessage = "Tipo de documento nao aceite")]
        public IFormFile FormFiles { get; set; } // convert to list

    }
}
