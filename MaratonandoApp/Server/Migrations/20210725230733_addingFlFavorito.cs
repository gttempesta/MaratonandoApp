using Microsoft.EntityFrameworkCore.Migrations;

namespace MaratonandoApp.Server.Migrations
{
    public partial class addingFlFavorito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FlFavoritado",
                table: "SerieOnLibrary",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlFavoritado",
                table: "SerieOnLibrary");
        }
    }
}
