using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiServiceBackend.Migrations
{
    public partial class DBSkiService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mitarbeiters",
                columns: table => new
                {
                    MitarbeiterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mitarbeiters", x => x.MitarbeiterId);
                });

            migrationBuilder.CreateTable(
                name: "serviceDienstleistungen",
                columns: table => new
                {
                    DienstleistungenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DienstleistungsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preis = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceDienstleistungen", x => x.DienstleistungenId);
                });

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

            migrationBuilder.CreateTable(
                name: "serviceAuftrag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Auftrags = table.Column<int>(type: "int", nullable: false),
                    DienstleistungenId = table.Column<int>(type: "int", nullable: false),
                    priorität = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KundenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceAuftrag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_serviceAuftrag_serviceDienstleistungen_DienstleistungenId",
                        column: x => x.DienstleistungenId,
                        principalTable: "serviceDienstleistungen",
                        principalColumn: "DienstleistungenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mitarbeiterLogins_MitarbeiterId",
                table: "mitarbeiterLogins",
                column: "MitarbeiterId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceAuftrag_DienstleistungenId",
                table: "serviceAuftrag",
                column: "DienstleistungenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mitarbeiterLogins");

            migrationBuilder.DropTable(
                name: "serviceAuftrag");

            migrationBuilder.DropTable(
                name: "mitarbeiters");

            migrationBuilder.DropTable(
                name: "serviceDienstleistungen");
        }
    }
}
