using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class stellarAndSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bases_Systems_TSystemId",
                table: "Bases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemTBases",
                table: "SystemTBases");

            migrationBuilder.DropIndex(
                name: "IX_SystemTBases_TSystemId",
                table: "SystemTBases");

            migrationBuilder.DropIndex(
                name: "IX_Bases_TSystemId",
                table: "Bases");

            migrationBuilder.DropColumn(
                name: "SelectedBaseIds",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "TSystemId",
                table: "Bases");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SystemTBases",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemTBases",
                table: "SystemTBases",
                columns: new[] { "TSystemId", "TBaseId" });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StellarDensity = table.Column<string>(type: "TEXT", nullable: false),
                    StellerSolo = table.Column<string>(type: "TEXT", nullable: false),
                    StellerBinary = table.Column<string>(type: "TEXT", nullable: false),
                    StellerTrinary = table.Column<string>(type: "TEXT", nullable: false),
                    GasGiantPresent = table.Column<string>(type: "TEXT", nullable: false),
                    GasGiantCount = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanetoidBeltPresent = table.Column<string>(type: "TEXT", nullable: false),
                    PlanetoidBeltCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StellarTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    CompanionType = table.Column<string>(type: "TEXT", nullable: false),
                    CompanionSize = table.Column<string>(type: "TEXT", nullable: false),
                    CompanionOrbit = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StellarZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TStellarTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Orbit = table.Column<int>(type: "INTEGER", nullable: false),
                    Zone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StellarZones_StellarTypes_TStellarTypeId",
                        column: x => x.TStellarTypeId,
                        principalTable: "StellarTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StellarZones_TStellarTypeId",
                table: "StellarZones",
                column: "TStellarTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "StellarZones");

            migrationBuilder.DropTable(
                name: "StellarTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemTBases",
                table: "SystemTBases");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SystemTBases",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedBaseIds",
                table: "Systems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TSystemId",
                table: "Bases",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemTBases",
                table: "SystemTBases",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SystemTBases_TSystemId",
                table: "SystemTBases",
                column: "TSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Bases_TSystemId",
                table: "Bases",
                column: "TSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bases_Systems_TSystemId",
                table: "Bases",
                column: "TSystemId",
                principalTable: "Systems",
                principalColumn: "Id");
        }
    }
}
