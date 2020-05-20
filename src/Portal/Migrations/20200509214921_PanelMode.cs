using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class PanelMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visible",
                schema: "dbo",
                table: "Panels");

            migrationBuilder.AlterColumn<int>(
                name: "ReadOnly",
                schema: "dbo",
                table: "Panels",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                schema: "dbo",
                table: "Panels",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PanelType",
                schema: "dbo",
                table: "Panels",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hidden",
                schema: "dbo",
                table: "Panels");

            migrationBuilder.DropColumn(
                name: "PanelType",
                schema: "dbo",
                table: "Panels");

            migrationBuilder.AlterColumn<bool>(
                name: "ReadOnly",
                schema: "dbo",
                table: "Panels",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                schema: "dbo",
                table: "Panels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
