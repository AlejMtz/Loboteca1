namespace Loboteca1.Models
{
    public class AutorRevistaModel
    {
        public int Id { get; set; }
        public int IdAutor { get; set; }
        public AutorModel Autor { get; set; } // Relación con AutorModel
        public int IdRevista { get; set; }
        public RevistaModel Revista { get; set; } // Relación con RevistaModel
    }
}
