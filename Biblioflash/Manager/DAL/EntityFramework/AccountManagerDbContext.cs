using Biblioflash.Manager.DAL.EntityFramework.Mapping;
using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class AccountManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=batyr.db.elephantsql.com;Port=5432;User Id=qjunmrli;Password=T9bxHew6sJcGYBLoXaUkmRXLFN4DlPbR;Database=qjunmrli");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EjemplarConfiguration());
            modelBuilder.ApplyConfiguration(new LibroConfiguration());
            modelBuilder.ApplyConfiguration(new NotificacionConfiguration());
            modelBuilder.ApplyConfiguration(new PrestamoConfiguration());
        }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Libro> Libros { get; set; }

        public DbSet<Ejemplar> Ejemplares { get; set; }

        public DbSet<Prestamo> Prestamos { get; set; }

        public DbSet<Notificacion> Notificaciones { get; set; }

    }
}
