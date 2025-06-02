using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HallCrawler.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CssPagnationLinkSelector",
                table: "MainWebCrawlers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CssPagnationSelector",
                table: "MainWebCrawlers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CssPagnationLinkSelector",
                table: "MainWebCrawlers");

            migrationBuilder.DropColumn(
                name: "CssPagnationSelector",
                table: "MainWebCrawlers");
        }
    }
}
