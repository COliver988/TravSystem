using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class systemBases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Systems_SubSectors_SubSectorId",
                table: "Systems");

            migrationBuilder.DropTable(
                name: "PlanetBases");

            migrationBuilder.DropTable(
                name: "TBaseTPlanet");

            migrationBuilder.AddColumn<string>(
                name: "SelectedBaseIds",
                table: "Systems",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "TSystemId",
                table: "Bases",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SystemTBases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TSystemId = table.Column<int>(type: "INTEGER", nullable: false),
                    TBaseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemTBases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemTBases_Bases_TBaseId",
                        column: x => x.TBaseId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemTBases_Systems_TSystemId",
                        column: x => x.TSystemId,
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bases_TSystemId",
                table: "Bases",
                column: "TSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemTBases_TBaseId",
                table: "SystemTBases",
                column: "TBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemTBases_TSystemId",
                table: "SystemTBases",
                column: "TSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bases_Systems_TSystemId",
                table: "Bases",
                column: "TSystemId",
                principalTable: "Systems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Systems_SubSectors_SubSectorId",
                table: "Systems",
                column: "SubSectorId",
                principalTable: "SubSectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bases_Systems_TSystemId",
                table: "Bases");

            migrationBuilder.DropForeignKey(
                name: "FK_Systems_SubSectors_SubSectorId",
                table: "Systems");

            migrationBuilder.DropTable(
                name: "SystemTBases");

            migrationBuilder.DropIndex(
                name: "IX_Bases_TSystemId",
                table: "Bases");

            migrationBuilder.DropColumn(
                name: "SelectedBaseIds",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "TSystemId",
                table: "Bases");

            migrationBuilder.CreateTable(
                name: "PlanetBases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TBaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    TPlanetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetBases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBaseTPlanet",
                columns: table => new
                {
                    BasesId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanetsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBaseTPlanet", x => new { x.BasesId, x.PlanetsId });
                    table.ForeignKey(
                        name: "FK_TBaseTPlanet_Bases_BasesId",
                        column: x => x.BasesId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBaseTPlanet_Planets_PlanetsId",
                        column: x => x.PlanetsId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBaseTPlanet_PlanetsId",
                table: "TBaseTPlanet",
                column: "PlanetsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Systems_SubSectors_SubSectorId",
                table: "Systems",
                column: "SubSectorId",
                principalTable: "SubSectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
