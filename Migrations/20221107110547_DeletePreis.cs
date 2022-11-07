using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiServiceBackend.Migrations
{
    public partial class DeletePreis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preis",
                table: "serviceDienstleistungen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Preis",
                table: "serviceDienstleistungen",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
