using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loboteca1.Models
{
    [Table("carrera")]  // Mapeo explícito al nombre de la tabla
    public class CarreraModel
    {
        [Key]  // Especificamos que es la clave primaria
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre de la carrera es obligatorio")]
        [StringLength(100)]
        public string nombre_de_la_carrera { get; set; }

        [StringLength(100)]
        public string estado { get; set; }  // Varchar para almacenar el estado como cadena de texto
    }
}
