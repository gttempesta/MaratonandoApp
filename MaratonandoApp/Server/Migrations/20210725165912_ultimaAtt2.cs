using Microsoft.EntityFrameworkCore.Migrations;

namespace MaratonandoApp.Server.Migrations
{
    public partial class ultimaAtt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_serieLibraries_AspNetUsers_UserId",
                table: "serieLibraries");

            migrationBuilder.DropForeignKey(
                name: "FK_SerieOnLibrary_serieLibraries_SerieLibraryId",
                table: "SerieOnLibrary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_serieLibraries",
                table: "serieLibraries");

            migrationBuilder.RenameTable(
                name: "serieLibraries",
                newName: "SerieLibrary");

            migrationBuilder.RenameIndex(
                name: "IX_serieLibraries_UserId",
                table: "SerieLibrary",
                newName: "IX_SerieLibrary_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SerieLibrary",
                table: "SerieLibrary",
                column: "SerieLibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SerieLibrary_AspNetUsers_UserId",
                table: "SerieLibrary",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SerieOnLibrary_SerieLibrary_SerieLibraryId",
                table: "SerieOnLibrary",
                column: "SerieLibraryId",
                principalTable: "SerieLibrary",
                principalColumn: "SerieLibraryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerieLibrary_AspNetUsers_UserId",
                table: "SerieLibrary");

            migrationBuilder.DropForeignKey(
                name: "FK_SerieOnLibrary_SerieLibrary_SerieLibraryId",
                table: "SerieOnLibrary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SerieLibrary",
                table: "SerieLibrary");

            migrationBuilder.RenameTable(
                name: "SerieLibrary",
                newName: "serieLibraries");

            migrationBuilder.RenameIndex(
                name: "IX_SerieLibrary_UserId",
                table: "serieLibraries",
                newName: "IX_serieLibraries_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_serieLibraries",
                table: "serieLibraries",
                column: "SerieLibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_serieLibraries_AspNetUsers_UserId",
                table: "serieLibraries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SerieOnLibrary_serieLibraries_SerieLibraryId",
                table: "SerieOnLibrary",
                column: "SerieLibraryId",
                principalTable: "serieLibraries",
                principalColumn: "SerieLibraryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
