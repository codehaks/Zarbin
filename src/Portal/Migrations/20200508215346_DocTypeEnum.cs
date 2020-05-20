using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class DocTypeEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocType",
                schema: "dbo",
                table: "Docs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocType",
                schema: "dbo",
                table: "Docs");
        }
    }
}
