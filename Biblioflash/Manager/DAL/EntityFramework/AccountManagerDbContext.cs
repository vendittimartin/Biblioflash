﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioflash.Manager.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biblioflash.Manager.DAL.EntityFramework
{
    public class AccountManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=batyr.db.elephantsql.com;Database=qjunmrli;Username=qjunmrli;Password=T9bxHew6sJcGYBLoXaUkmRXLFN4DlPbR;");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EjemplarConfiguration());
            modelBuilder.ApplyConfiguration(new LibroConfiguration());
            modelBuilder.ApplyConfiguration(new NotificacionConfiguration());
            modelBuilder.ApplyConfiguration(new PrestamoConfiguration());
        }*/
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Libro> Libros { get; set; }

        public DbSet<Ejemplar> Ejemplares { get; set; }

        public DbSet<Prestamo> Prestamos { get; set; }

        public DbSet<Notificacion> Notifiaciones { get; set; }

    }
}
