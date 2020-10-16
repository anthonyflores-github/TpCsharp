using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TpBooks.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    PublishedDate = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PageCount = table.Column<int>(nullable: false),
                    PrintType = table.Column<string>(nullable: true),
                    AverageRating = table.Column<int>(nullable: false),
                    RatingsCount = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    PreviewLink = table.Column<string>(nullable: true),
                    InfoLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Shelves");
        }
    }
}
