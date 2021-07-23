using Microsoft.EntityFrameworkCore.Migrations;

namespace MaratonandoApp.Server.Migrations
{
    public partial class ArrumandoComentarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmComments_Films_FilmId",
                table: "FilmComments");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "FilmComments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FilmComments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmComments_Films_FilmId",
                table: "FilmComments",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmComments_Films_FilmId",
                table: "FilmComments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FilmComments");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "FilmComments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmComments_Films_FilmId",
                table: "FilmComments",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
