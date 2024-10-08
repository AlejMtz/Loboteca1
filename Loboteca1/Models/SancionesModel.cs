namespace Loboteca1.Models
{
    public class SancionesModel
    {
        public int Id { get; set; }
        public int IdEstado { get; set; }
        public EstadoModel Estado { get; set; } // Relación con EstadoModel
        public int IdAlumno { get; set; }
        public AlumnoModel Alumno { get; set; } // Relación con AlumnoModel
        public int IdPrestamo { get; set; }
        public PrestamoModel Prestamo { get; set; } // Relación con PrestamoModel
        public int IdPenalizacion { get; set; }
        public ConfiguracionPenalizacionesModel Penalizacion { get; set; } // Relación con ConfiguracionPenalizacionesModel
    }
}
