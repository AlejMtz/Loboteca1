using System.ComponentModel.DataAnnotations;

namespace Loboteca1.Models
{
    public class EditorialModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la editorial es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(100)]
        public string Estado { get; set; } // Este será un varchar y no una relación
    }
}
