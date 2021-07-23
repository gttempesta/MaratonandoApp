using Microsoft.EntityFrameworkCore.Migrations;

namespace MaratonandoApp.Server.Migrations
{
    public partial class ComComentariosNovo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_filmComments_AspNetUsers_ApplicationUserId",
                table: "filmComments");

            migrationBuilder.DropForeignKey(
                name: "FK_filmComments_Films_FilmId1",
                table: "filmComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_filmComments",
                table: "filmComments");

            migrationBuilder.DropIndex(
                name: "IX_filmComments_FilmId1",
                table: "filmComments");

            migrationBuilder.DropColumn(
                name: "FilmId1",
                table: "filmComments");

            migrationBuilder.RenameTable(
                name: "filmComments",
                newName: "FilmComment");

            migrationBuilder.RenameIndex(
                name: "IX_filmComments_ApplicationUserId",
                table: "FilmComment",
                newName: "IX_FilmComment_ApplicationUserId");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "FilmComment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmComment",
                table: "FilmComment",
                column: "FilmCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmComment_FilmId",
                table: "FilmComment",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmComment_AspNetUsers_ApplicationUserId",
                table: "FilmComment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmComment_Films_FilmId",
                table: "FilmComment",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmComment_AspNetUsers_ApplicationUserId",
                table: "FilmComment");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmComment_Films_FilmId",
                table: "FilmComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmComment",
                table: "FilmComment");

            migrationBuilder.DropIndex(
                name: "IX_FilmComment_FilmId",
                table: "FilmComment");

            migrationBuilder.RenameTable(
                name: "FilmComment",
                newName: "filmComments");

            migrationBuilder.RenameIndex(
                name: "IX_FilmComment_ApplicationUserId",
                table: "filmComments",
                newName: "IX_filmComments_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "FilmId",
                table: "filmComments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FilmId1",
                table: "filmComments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_filmComments",
                table: "filmComments",
                column: "FilmCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_filmComments_FilmId1",
                table: "filmComments",
                column: "FilmId1");

            migrationBuilder.AddForeignKey(
                name: "FK_filmComments_AspNetUsers_ApplicationUserId",
                table: "filmComments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_filmComments_Films_FilmId1",
                table: "filmComments",
                column: "FilmId1",
                principalTable: "Films",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
