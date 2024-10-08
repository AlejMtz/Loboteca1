using Microsoft.EntityFrameworkCore;

namespace Loboteca1.Models
{
    public class LobotecaContext : DbContext
    {
        public LobotecaContext(DbContextOptions<LobotecaContext> options) : base(options)
        {
        }

        public DbSet<LibroModel> Libros { get; set; } = null!;
        public DbSet<AlumnoModel> Alumnos { get; set; } = null!;
        public DbSet<RevistaModel> Revistas { get; set; } = null!;
        public DbSet<EstadoModel> Estado { get; set; } = null!;
        public DbSet<CarreraModel> Carreras { get; set; } = null!;
        public DbSet<AdministradorModel> Administrador { get; set; } = null!;
        public DbSet<ConfiguracionPenalizacionesModel> configuracion_penalizaciones { get; set; } = null!;
        public DbSet<SancionesModel> Sanciones { get; set; } = null!;
        public DbSet<AutorModel> Autor { get; set; } = null!;
        public DbSet<AutorLibroModel> AutorLibros { get; set; } = null!;
        public DbSet<ELibroModel> ELibros { get; set; } = null!;
        public DbSet<AutorELibroModel> AutorELibros { get; set; } = null!;
        public DbSet<AutorRevistaModel> AutorRevistas { get; set; } = null!;
        public DbSet<PrestamoModel> Prestamos { get; set; } = null!;
        public DbSet<EditorialModel> Editorial { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EditorialModel>()
                .HasOne(e => e.Estado)
                .WithMany()
                .HasForeignKey(e => e.Id_Estado);

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<EditorialModel>()
    .HasOne(e => e.Estado)
    .WithMany()
    .HasForeignKey(e => e.Id_Estado);  // Aquí debe ser 'id_estado', que referencia 'id' en Estado

        }
    }
}
