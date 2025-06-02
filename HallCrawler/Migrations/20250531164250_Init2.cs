using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HallCrawler.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CssInformationSelector",
                table: "MainWebCrawlers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CssInformationSelector",
                table: "MainWebCrawlers");
        }
    }
}
