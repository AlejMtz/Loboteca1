using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loboteca1.Models
{
    [Table("editorial")]
    public class EditorialModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [ForeignKey("Estado")]
        public int Id_Estado { get; set; }

        public EstadoModel Estado { get; set; }
    }
}
