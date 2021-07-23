using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaratonandoApp.Server.Migrations
{
    public partial class ComComentariosNovo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "filmComments",
                columns: table => new
                {
                    FilmCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilmId1 = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filmComments", x => x.FilmCommentId);
                    table.ForeignKey(
                        name: "FK_filmComments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_filmComments_Films_FilmId1",
                        column: x => x.FilmId1,
                        principalTable: "Films",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_filmComments_ApplicationUserId",
                table: "filmComments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_filmComments_FilmId1",
                table: "filmComments",
                column: "FilmId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "filmComments");
        }
    }
}
