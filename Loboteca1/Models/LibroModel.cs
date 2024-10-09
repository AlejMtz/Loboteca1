namespace Loboteca1.Models
{
    public class LibroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public DateTime FechaDePublicacion { get; set; }
        public string Genero { get; set; }
        public int IdEstado { get; set; }
        public string RutaImagen { get; set; }
        public int Stock { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int IdEditorial { get; set; }
        public EditorialModel Editorial { get; set; } // Relación con EditorialModel
    }
}
