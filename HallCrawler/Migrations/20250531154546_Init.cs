using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HallCrawler.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HallItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Services = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainWebCrawlers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CssHallsSelector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CssHallLinkSelector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CssTitleSelecto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CssImageHallSelector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CssServicesSelector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CssManagerNameSelector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CssTelHallSelector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CssCellphoneHallSelector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CssTag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainWebCrawlers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HallItems");

            migrationBuilder.DropTable(
                name: "MainWebCrawlers");
        }
    }
}
