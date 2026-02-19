using appWeb21.Models;
using Microsoft.EntityFrameworkCore;

namespace appWeb21.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Definición de los DbSet para cada entidad
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<VideoJuego> VideoJuegos { get; set; }
        public DbSet<Compra> Compras { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración de la entidad Usuario
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Configuración de la relación entre Compra, Usuario y VideoJuego
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Compras)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración de la relación entre Compra, Usuario y VideoJuego
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.VideoJuego)
                .WithMany(v => v.Compras)
                .HasForeignKey(c => c.VideoJuegoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    

}
