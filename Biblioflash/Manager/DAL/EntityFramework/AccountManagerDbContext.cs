using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    class AccountManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=batyr.db.elephantsql.com;Port=5432;User Id=qjunmrli;Password=T9bxHew6sJcGYBLoXaUkmRXLFN4DlPbR;Database=qjunmrli");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Libro> Libros { get; set; }

        public DbSet<Ejemplar> Ejemplares { get; set; }

        public DbSet<Prestamo> Prestamos { get; set; }

        public DbSet<Notificacion> Notifiaciones { get; set; }

    }
}
