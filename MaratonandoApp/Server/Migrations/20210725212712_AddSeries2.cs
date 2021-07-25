using Microsoft.EntityFrameworkCore.Migrations;

namespace MaratonandoApp.Server.Migrations
{
    public partial class AddSeries2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episode_Serie_SerieId",
                table: "Episode");

            migrationBuilder.DropForeignKey(
                name: "FK_SerieOnLibrary_Serie_SerieId",
                table: "SerieOnLibrary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Serie",
                table: "Serie");

            migrationBuilder.RenameTable(
                name: "Serie",
                newName: "Series");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Series",
                table: "Series",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episode_Series_SerieId",
                table: "Episode",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "SerieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SerieOnLibrary_Series_SerieId",
                table: "SerieOnLibrary",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "SerieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episode_Series_SerieId",
                table: "Episode");

            migrationBuilder.DropForeignKey(
                name: "FK_SerieOnLibrary_Series_SerieId",
                table: "SerieOnLibrary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Series",
                table: "Series");

            migrationBuilder.RenameTable(
                name: "Series",
                newName: "Serie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Serie",
                table: "Serie",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episode_Serie_SerieId",
                table: "Episode",
                column: "SerieId",
                principalTable: "Serie",
                principalColumn: "SerieId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SerieOnLibrary_Serie_SerieId",
                table: "SerieOnLibrary",
                column: "SerieId",
                principalTable: "Serie",
                principalColumn: "SerieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
