using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class WebPageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Panels",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "WebPages",
                schema: "dbo",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Title = table.Column<string>(maxLength: 25, nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Hidden = table.Column<bool>(nullable: false),
                    ReadOnly = table.Column<int>(nullable: false),
                    PanelType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebPages", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebPages",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "Panels",
                schema: "dbo",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hidden = table.Column<bool>(type: "bit", nullable: false),
                    PanelType = table.Column<int>(type: "int", nullable: false),
                    ReadOnly = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panels", x => x.Name);
                });
        }
    }
}
