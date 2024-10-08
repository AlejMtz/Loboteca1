using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loboteca1.Models
{
    [Table("carrera")]  // Mapeo explícito al nombre de la tabla
    public class CarreraModel
    {
        [Key]  // Clave primaria
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la carrera es obligatorio")]
        [StringLength(100)]
        public string Nombre_de_la_carrera { get; set; }

        [ForeignKey("Estado")]
        public int Id_estado { get; set; }

        // Relación con el modelo Estado
        public EstadoModel Estado { get; set; }
    }
}
