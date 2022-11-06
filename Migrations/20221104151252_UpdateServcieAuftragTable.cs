using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiServiceBackend.Migrations
{
    public partial class UpdateServcieAuftragTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Auftrags",
                table: "serviceAuftrag");

            migrationBuilder.AddColumn<DateTime>(
                name: "Create_Date",
                table: "serviceAuftrag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Pickup_Date",
                table: "serviceAuftrag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Create_Date",
                table: "serviceAuftrag");

            migrationBuilder.DropColumn(
                name: "Pickup_Date",
                table: "serviceAuftrag");

            migrationBuilder.AddColumn<int>(
                name: "Auftrags",
                table: "serviceAuftrag",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
