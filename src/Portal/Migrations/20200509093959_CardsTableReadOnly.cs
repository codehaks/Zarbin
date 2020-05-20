using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class CardsTableReadOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReadOnly",
                schema: "dbo",
                table: "Cards",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadOnly",
                schema: "dbo",
                table: "Cards");
        }
    }
}
