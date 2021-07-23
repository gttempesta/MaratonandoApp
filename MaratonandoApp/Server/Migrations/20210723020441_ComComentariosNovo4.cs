using Microsoft.EntityFrameworkCore.Migrations;

namespace MaratonandoApp.Server.Migrations
{
    public partial class ComComentariosNovo4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserUsername",
                table: "FilmComment");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FilmComment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FilmComment");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserUsername",
                table: "FilmComment",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
