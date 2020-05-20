using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class PanelsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "Panels",
                schema: "dbo",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Body = table.Column<string>(nullable: true),
                    Visible = table.Column<bool>(nullable: false),
                    ReadOnly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panels", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Panels",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "Cards",
                schema: "dbo",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Name);
                });
        }
    }
}
