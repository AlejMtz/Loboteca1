using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Loboteca1.Models
{
    [Table("Estado")]
    public class EstadoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del estado es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
