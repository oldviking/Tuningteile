using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuningteile.Migrations
{
    public partial class auth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "salt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "salt",
                table: "Users");
        }
    }
}
