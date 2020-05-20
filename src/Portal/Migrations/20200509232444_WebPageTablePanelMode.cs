using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class WebPageTablePanelMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadOnly",
                schema: "dbo",
                table: "WebPages");

            migrationBuilder.AddColumn<int>(
                name: "PanelMode",
                schema: "dbo",
                table: "WebPages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PanelMode",
                schema: "dbo",
                table: "WebPages");

            migrationBuilder.AddColumn<int>(
                name: "ReadOnly",
                schema: "dbo",
                table: "WebPages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
