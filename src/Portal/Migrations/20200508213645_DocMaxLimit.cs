using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class DocMaxLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Docs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Docs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Docs");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "Docs");
        }
    }
}
