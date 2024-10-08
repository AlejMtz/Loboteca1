using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loboteca1.Models
{
    [Table("configuracion_penalizaciones")]  // Mapeo explícito al nombre de la tabla
    public class ConfiguracionPenalizacionesModel
    {
        [Key]  // Especificamos que es la clave primaria
        public int id_penalizacion { get; set; }

        public string nombre { get; set; }

        public decimal monto { get; set; }
    }
}
