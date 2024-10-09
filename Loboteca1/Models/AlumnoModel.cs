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
    }
}
