using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WeblawyersBox.servicos
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class PermittedExtensionsAttribute : ValidationAttribute
    {
      
       
            private List<string> AllowedExtensions { get; set; }

            public PermittedExtensionsAttribute(string fileExtensions)
            {
                AllowedExtensions = fileExtensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

         
        }
    }
