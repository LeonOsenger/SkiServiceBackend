using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiServiceBackend.Migrations
{
    public partial class DeleteWrongColum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuftragsPriorität",
                table: "serviceDienstleistungen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuftragsPriorität",
                table: "serviceDienstleistungen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
