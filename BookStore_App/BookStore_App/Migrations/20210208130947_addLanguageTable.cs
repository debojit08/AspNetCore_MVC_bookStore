using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore_App.Migrations
{
    public partial class addLanguageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "books");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_language", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_LanguageId",
                table: "books",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_language_LanguageId",
                table: "books",
                column: "LanguageId",
                principalTable: "language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_language_LanguageId",
                table: "books");

            migrationBuilder.DropTable(
                name: "language");

            migrationBuilder.DropIndex(
                name: "IX_books_LanguageId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "books");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
