using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioflash.Migrations
{
    public partial class myMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Autor",
                table: "Libros",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 500);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Autor",
                table: "Libros",
                type: "integer",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);
        }
    }
}
