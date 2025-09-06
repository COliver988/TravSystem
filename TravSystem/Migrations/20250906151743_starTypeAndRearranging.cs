using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class starTypeAndRearranging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zone",
                table: "StellarZones");

            migrationBuilder.DropColumn(
                name: "CompanionOrbit",
                table: "StellarTypes");

            migrationBuilder.DropColumn(
                name: "CompanionSize",
                table: "StellarTypes");

            migrationBuilder.DropColumn(
                name: "CompanionType",
                table: "StellarTypes");

            migrationBuilder.RenameColumn(
                name: "Orbit",
                table: "StellarZones",
                newName: "InnerZoneLow");

            migrationBuilder.AddColumn<int>(
                name: "HabitableZone",
                table: "StellarZones",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InnerZoneHigh",
                table: "StellarZones",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StarTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarTypes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StarTypes");

            migrationBuilder.DropColumn(
                name: "HabitableZone",
                table: "StellarZones");

            migrationBuilder.DropColumn(
                name: "InnerZoneHigh",
                table: "StellarZones");

            migrationBuilder.RenameColumn(
                name: "InnerZoneLow",
                table: "StellarZones",
                newName: "Orbit");

            migrationBuilder.AddColumn<string>(
                name: "Zone",
                table: "StellarZones",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanionOrbit",
                table: "StellarTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanionSize",
                table: "StellarTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanionType",
                table: "StellarTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
