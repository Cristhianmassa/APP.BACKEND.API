using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Autores.Entidades.Validaciones
{ 
    //reglas de valición por atributo
    internal class PrimeraLetraMayusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Si no hay string no debe valida y no se cruce con required.
            if (value == null || string.IsNullOrEmpty(value.ToString())) 
            {
                return ValidationResult.Success;
            }

            var primeraLetra = value.ToString()[0].ToString();
            if (primeraLetra!=primeraLetra.ToUpper())
            {
                return new ValidationResult("La primera letra debe ser mayúscula.");
            }

            return ValidationResult.Success;

        }
    }
}
