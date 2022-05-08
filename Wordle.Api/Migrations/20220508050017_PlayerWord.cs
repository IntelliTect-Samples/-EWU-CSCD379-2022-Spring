using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    public partial class PlayerWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Letters = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.WordId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerWords",
                columns: table => new
                {
                    PlayerWordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    DateStarted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateEnded = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerWords", x => x.PlayerWordId);
                    table.ForeignKey(
                        name: "FK_PlayerWords_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerWordGuesss",
                columns: table => new
                {
                    PlayerWordGuessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerWordId = table.Column<int>(type: "int", nullable: false),
                    Guess = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuessIsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    GuessDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    GuessNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerWordGuesss", x => x.PlayerWordGuessId);
                    table.ForeignKey(
                        name: "FK_PlayerWordGuesss_PlayerWords_PlayerWordId",
                        column: x => x.PlayerWordId,
                        principalTable: "PlayerWords",
                        principalColumn: "PlayerWordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerWordGuesss_PlayerWordId",
                table: "PlayerWordGuesss",
                column: "PlayerWordId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerWords_PlayerId",
                table: "PlayerWords",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerWords_WordId",
                table: "PlayerWords",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerWordGuesss");

            migrationBuilder.DropTable(
                name: "PlayerWords");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
