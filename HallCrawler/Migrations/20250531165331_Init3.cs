using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HallCrawler.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CssCellphoneHallSelector",
                table: "MainWebCrawlers");

            migrationBuilder.DropColumn(
                name: "CssManagerNameSelector",
                table: "MainWebCrawlers");

            migrationBuilder.DropColumn(
                name: "CssTag",
                table: "MainWebCrawlers");

            migrationBuilder.DropColumn(
                name: "CssTelHallSelector",
                table: "MainWebCrawlers");

            migrationBuilder.RenameColumn(
                name: "CssTitleSelecto",
                table: "MainWebCrawlers",
                newName: "CssTitleSelector");

            migrationBuilder.AddColumn<string>(
                name: "Capacity",
                table: "HallItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "HallItems");

            migrationBuilder.RenameColumn(
                name: "CssTitleSelector",
                table: "MainWebCrawlers",
                newName: "CssTitleSelecto");

            migrationBuilder.AddColumn<string>(
                name: "CssCellphoneHallSelector",
                table: "MainWebCrawlers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CssManagerNameSelector",
                table: "MainWebCrawlers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CssTag",
                table: "MainWebCrawlers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CssTelHallSelector",
                table: "MainWebCrawlers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
