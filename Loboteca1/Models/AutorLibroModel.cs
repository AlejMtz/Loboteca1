namespace Loboteca1.Models
{
    public class AutorLibroModel
    {
        public int Id { get; set; }
        public int IdAutor { get; set; }
        public AutorModel Autor { get; set; } // Relación con AutorModel
        public int IdLibro { get; set; }
        public LibroModel Libro { get; set; } // Relación con LibroModel
    }
}
