using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiServiceBackend.Migrations
{
    public partial class UpdateServcieAuftrag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "priorität",
                table: "serviceAuftrag",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "serviceAuftrag",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "serviceAuftrag");

            migrationBuilder.AlterColumn<string>(
                name: "priorität",
                table: "serviceAuftrag",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
