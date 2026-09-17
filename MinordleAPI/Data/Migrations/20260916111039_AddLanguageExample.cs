using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinordleAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguageExample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LanguageName = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageFamily = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageExample = table.Column<string>(type: "TEXT", nullable: false),
                    YellowImg = table.Column<string>(type: "TEXT", nullable: false),
                    GreenImg = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageDescription = table.Column<string>(type: "TEXT", nullable: true),
                    audioFile = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    HighScore = table.Column<int>(type: "INTEGER", nullable: false),
                    GameResults = table.Column<string>(type: "TEXT", nullable: false),
                    streak = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
