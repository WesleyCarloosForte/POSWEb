using SharedProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject.Validaciones.Comprobante
{
 public class  FechaFinalValorFiscalAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var numeracionComprobante = (NumeracionComprobante)validationContext.ObjectInstance;

        if (numeracionComprobante.ValorFiscal == false && value != null && (DateTime)value < DateTime.Now)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}
}
