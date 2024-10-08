namespace Loboteca1.Models
{
    public class AutorELibroModel
    {
        public int Id { get; set; }
        public int IdAutor { get; set; }
        public AutorModel Autor { get; set; } // Relación con AutorModel
        public int IdELibro { get; set; }
        public ELibroModel ELibro { get; set; } // Relación con ELibroModel
    }
}
