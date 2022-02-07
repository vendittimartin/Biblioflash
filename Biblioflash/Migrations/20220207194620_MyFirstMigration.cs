using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Biblioflash.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Isbn = table.Column<long>(type: "bigint", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Autor = table.Column<int>(type: "integer", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.ID);
                    table.UniqueConstraint("AK_Libros_Isbn", x => x.Isbn);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    NombreUsuario = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Contraseña = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Mail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RangoUsuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                    table.UniqueConstraint("AK_Usuarios_NombreUsuario", x => x.NombreUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Ejemplares",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LibroID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejemplares", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ejemplares_Libros_LibroID",
                        column: x => x.LibroID,
                        principalTable: "Libros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaRealDevolucion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FechaPrestamo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UsuarioID = table.Column<long>(type: "bigint", nullable: true),
                    EjemplarID = table.Column<long>(type: "bigint", nullable: true),
                    estadoPrestamo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prestamos_Ejemplares_EjemplarID",
                        column: x => x.EjemplarID,
                        principalTable: "Ejemplares",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifiaciones",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioID = table.Column<long>(type: "bigint", nullable: true),
                    PrestamoID = table.Column<long>(type: "bigint", nullable: true),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Asunto = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifiaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notifiaciones_Prestamos_PrestamoID",
                        column: x => x.PrestamoID,
                        principalTable: "Prestamos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifiaciones_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ejemplares_LibroID",
                table: "Ejemplares",
                column: "LibroID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifiaciones_PrestamoID",
                table: "Notifiaciones",
                column: "PrestamoID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifiaciones_UsuarioID",
                table: "Notifiaciones",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_EjemplarID",
                table: "Prestamos",
                column: "EjemplarID");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_UsuarioID",
                table: "Prestamos",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifiaciones");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Ejemplares");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
