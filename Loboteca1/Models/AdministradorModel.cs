namespace Loboteca1.Models
{
    public class AdministradorModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string numero_de_empleado { get; set; }
        public DateTime? fecha_de_inicio { get; set; }
        public DateTime? fecha_de_termino { get; set; }
    }
}
