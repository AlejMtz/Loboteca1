namespace Loboteca1.Models
{
    public class AlumnoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Matricula { get; set; }
        public int IdCarrera { get; set; }
        public CarreraModel Carrera { get; set; } // Relación con CarreraModel
        public int IdEstado { get; set; }
        public EstadoModel Estado { get; set; } // Relación con EstadoModel
    }
}
