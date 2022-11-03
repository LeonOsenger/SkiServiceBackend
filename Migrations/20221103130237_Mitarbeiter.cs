using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiServiceBackend.Migrations
{
    public partial class Mitarbeiter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mitarbeiterLogins");

            migrationBuilder.AddColumn<string>(
                name: "AuftragsPriorität",
                table: "serviceDienstleistungen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Passwort",
                table: "mitarbeiters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuftragsPriorität",
                table: "serviceDienstleistungen");

            migrationBuilder.DropColumn(
                name: "Passwort",
                table: "mitarbeiters");

            migrationBuilder.CreateTable(
                name: "mitarbeiterLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MitarbeiterId = table.Column<int>(type: "int", nullable: false),
                    Benutzername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passwort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mitarbeiterLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mitarbeiterLogins_mitarbeiters_MitarbeiterId",
                        column: x => x.MitarbeiterId,
                        principalTable: "mitarbeiters",
                        principalColumn: "MitarbeiterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mitarbeiterLogins_MitarbeiterId",
                table: "mitarbeiterLogins",
                column: "MitarbeiterId");
        }
    }
}
