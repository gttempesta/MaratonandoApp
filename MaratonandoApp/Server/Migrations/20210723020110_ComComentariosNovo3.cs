using Microsoft.EntityFrameworkCore.Migrations;

namespace MaratonandoApp.Server.Migrations
{
    public partial class ComComentariosNovo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserUsername",
                table: "FilmComment",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserUsername",
                table: "FilmComment");
        }
    }
}
