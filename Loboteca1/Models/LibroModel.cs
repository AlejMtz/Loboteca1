using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loboteca1.Models
{
    [Table("libro")]  // Mapeo explícito al nombre de la tabla
    public class LibroModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string titulo { get; set; }

        [StringLength(20)]
        public string ISBN { get; set; }

        public DateTime? fecha_de_publicacion { get; set; }

        [StringLength(100)]
        public string genero { get; set; }

        [StringLength(100)]
        public string estado { get; set; }

        [StringLength(255)]
        public string ruta_imagen { get; set; }

        public int stock { get; set; }

        public DateTime? fecha_de_alta { get; set; }

        // Relación con Editorial
        [ForeignKey("Editorial")]
        public int? id_editorial { get; set; }

        public virtual EditorialModel Editorial { get; set; }  // Relación de navegación
    }
}
