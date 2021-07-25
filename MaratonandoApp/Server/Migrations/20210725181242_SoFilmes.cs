using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaratonandoApp.Server.Migrations
{
    public partial class SoFilmes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodeComment");

            migrationBuilder.DropTable(
                name: "EpisodeOnLibraries");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "EpisodeLibrary");

            migrationBuilder.DropTable(
                name: "SerieOnLibrary");

            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.DropTable(
                name: "SerieLibrary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    SerieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEstreia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Poster = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    QtdTemporadas = table.Column<int>(type: "int", nullable: false),
                    Sinopse = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.SerieId);
                });

            migrationBuilder.CreateTable(
                name: "SerieLibrary",
                columns: table => new
                {
                    SerieLibraryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieLibrary", x => x.SerieLibraryId);
                    table.ForeignKey(
                        name: "FK_SerieLibrary_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerieId = table.Column<int>(type: "int", nullable: true),
                    nroEpisode = table.Column<int>(type: "int", nullable: false),
                    nroTemporada = table.Column<int>(type: "int", nullable: false),
                    sinopse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.EpisodeId);
                    table.ForeignKey(
                        name: "FK_Episode_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "SerieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SerieOnLibrary",
                columns: table => new
                {
                    SerieOnLibraryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerieId = table.Column<int>(type: "int", nullable: false),
                    SerieLibraryId = table.Column<int>(type: "int", nullable: false),
                    SeriesStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieOnLibrary", x => x.SerieOnLibraryId);
                    table.ForeignKey(
                        name: "FK_SerieOnLibrary_Serie_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Serie",
                        principalColumn: "SerieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SerieOnLibrary_SerieLibrary_SerieLibraryId",
                        column: x => x.SerieLibraryId,
                        principalTable: "SerieLibrary",
                        principalColumn: "SerieLibraryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeComment",
                columns: table => new
                {
                    EpisodeCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EpisodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeComment", x => x.EpisodeCommentId);
                    table.ForeignKey(
                        name: "FK_EpisodeComment_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EpisodeComment_Episode_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episode",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeLibrary",
                columns: table => new
                {
                    EpisodeLibraryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerieOnLibraryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeLibrary", x => x.EpisodeLibraryId);
                    table.ForeignKey(
                        name: "FK_EpisodeLibrary_SerieOnLibrary_SerieOnLibraryId",
                        column: x => x.SerieOnLibraryId,
                        principalTable: "SerieOnLibrary",
                        principalColumn: "SerieOnLibraryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeOnLibraries",
                columns: table => new
                {
                    EpisodeLibraryId = table.Column<int>(type: "int", nullable: false),
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    DataAssistido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlAssistido = table.Column<bool>(type: "bit", nullable: false),
                    NotaEpisodio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeOnLibraries", x => new { x.EpisodeLibraryId, x.EpisodeId });
                    table.ForeignKey(
                        name: "FK_EpisodeOnLibraries_Episode_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episode",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeOnLibraries_EpisodeLibrary_EpisodeLibraryId",
                        column: x => x.EpisodeLibraryId,
                        principalTable: "EpisodeLibrary",
                        principalColumn: "EpisodeLibraryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episode_SerieId",
                table: "Episode",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeComment_ApplicationUserId",
                table: "EpisodeComment",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeComment_EpisodeId",
                table: "EpisodeComment",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeLibrary_SerieOnLibraryId",
                table: "EpisodeLibrary",
                column: "SerieOnLibraryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeOnLibraries_EpisodeId",
                table: "EpisodeOnLibraries",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SerieLibrary_UserId",
                table: "SerieLibrary",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SerieOnLibrary_SerieId",
                table: "SerieOnLibrary",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_SerieOnLibrary_SerieLibraryId",
                table: "SerieOnLibrary",
                column: "SerieLibraryId");
        }
    }
}
