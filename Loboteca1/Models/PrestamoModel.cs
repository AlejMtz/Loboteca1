namespace Loboteca1.Models
{
    public class PrestamoModel
    {
        public int Id { get; set; }
        public DateTime FechaDePrestamo { get; set; }
        public DateTime FechaDeDevolucion { get; set; }
        public int IdAdministrador { get; set; }
        public AdministradorModel Administrador { get; set; } // Relación con AdministradorModel
        public int IdEstado { get; set; }
        public int IdLibro { get; set; }
        public LibroModel Libro { get; set; } // Relación con LibroModel
    }
}
