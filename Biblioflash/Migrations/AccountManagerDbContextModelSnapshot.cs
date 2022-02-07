﻿// <auto-generated />
using System;
using Biblioflash.Manager.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Biblioflash.Migrations
{
    [DbContext(typeof(AccountManagerDbContext))]
    partial class AccountManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Biblioflash.Manager.Domain.Ejemplar", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("LibroID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("LibroID");

                    b.ToTable("Ejemplares");
                });

            modelBuilder.Entity("Biblioflash.Manager.Domain.Libro", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Autor")
                        .HasMaxLength(500)
                        .HasColumnType("integer");

                    b.Property<long>("Isbn")
                        .HasColumnType("bigint");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("ID");

                    b.HasAlternateKey("Isbn");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("Biblioflash.Manager.Domain.Notificacion", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Asunto")
                        .HasColumnType("text");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp without time zone");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("interval");

                    b.Property<long?>("PrestamoID")
                        .HasColumnType("bigint");

                    b.Property<long?>("UsuarioID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("PrestamoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Notifiaciones");
                });

            modelBuilder.Entity("Biblioflash.Manager.Domain.Prestamo", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("EjemplarID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FechaDevolucion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("FechaPrestamo")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("FechaRealDevolucion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("UsuarioID")
                        .HasColumnType("bigint");

                    b.Property<string>("estadoPrestamo")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("EjemplarID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("Biblioflash.Manager.Domain.Usuario", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("RangoUsuario")
                        .HasColumnType("integer");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasAlternateKey("NombreUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Biblioflash.Manager.Domain.Ejemplar", b =>
                {
                    b.HasOne("Biblioflash.Manager.Domain.Libro", "Libro")
                        .WithMany("Ejemplares")
                        .HasForeignKey("LibroID");

                    b.Navigation("Libro");
                });

            modelBuilder.Entity("Biblioflash.Manager.Domain.Notificacion", b =>
                {
                    b.HasOne("Biblioflash.Manager.Domain.Prestamo", "Prestamo")
                        .WithMany()
                        .HasForeignKey("PrestamoID");

                    b.HasOne("Biblioflash.Manager.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID");

                    b.Navigation("Prestamo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Biblioflash.Manager.Domain.Prestamo", b =>
                {
                    b.HasOne("Biblioflash.Manager.Domain.Ejemplar", "Ejemplar")
                        .WithMany("Prestamos")
                        .HasForeignKey("EjemplarID");

                    b.HasOne("Biblioflash.Manager.Domain.Usuario", "Usuario")
                        .WithMany("Prestamos")
                        .HasForeignKey("UsuarioID");

                    b.Navigation("Ejemplar");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Biblioflash.Manager.Domain.Ejemplar", b =>
                {
                    b.Navigation("Prestamos");
                });

            modelBuilder.Entity("Biblioflash.Manager.Domain.Libro", b =>
                {
                    b.Navigation("Ejemplares");
                });

            modelBuilder.Entity("Biblioflash.Manager.Domain.Usuario", b =>
                {
                    b.Navigation("Prestamos");
                });
#pragma warning restore 612, 618
        }
    }
}
