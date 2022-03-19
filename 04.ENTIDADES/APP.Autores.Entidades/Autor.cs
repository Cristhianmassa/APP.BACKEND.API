using APP.Autores.Entidades.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Autores.Entidades
{
    public class Autor : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido.")] //Validacion
        [StringLength(maximumLength:120, ErrorMessage ="El campo {0} no debe ser mayor de {1} carácteres.")]
        //[PrimeraLetraMayuscula] //En la carpeta Validaciones
        public string Nombre { get; set; }

        //[Range(18,120, ErrorMessage ="el campo {0} debe ser entre {1} y {2}")]
        //[NotMapped] //no se corresponde con columna de tabla
        //public int Edad { get; set; }

        //[CreditCard]
        //[NotMapped]
        //public string TarjetaCredito { get; set; }

        //[Url]
        //[NotMapped]
        //public string  URL { get; set; }

        //public int Menor { get; set; }
        //public int Mayor { get; set; }

        //[RegularExpression]
        public List<Libro> Libros { get; set; }

        //Validacion por modelo se necesita la interfaz IValidatableObject
        //Para que se ejecuten estar reglas tenemos que pasar primero las validaciones por cada campo
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if(!string.IsNullOrEmpty(Nombre))
            {
                var primeraLetra = Nombre[0].ToString();
                if (primeraLetra != primeraLetra.ToUpper())
                {
                    //yield insertar un elemento en la coleccion.
                    yield return new ValidationResult("La primera letra debe ser mayúscula.",
                        new string[] { nameof(Nombre) });
                }
            }

            //if (Menor > Mayor)
            //{
            //    yield return new ValidationResult("El valor del campo Menor no puede ser mas grande que el campo Mayor.",
            //           new string[] { nameof(Menor) });
            //}
        }

       

    }
}
