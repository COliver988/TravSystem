using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class systemPlanets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TSystemId",
                table: "Planets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TPlanetTSystem",
                columns: table => new
                {
                    PlanetsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TSystemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPlanetTSystem", x => new { x.PlanetsId, x.TSystemId });
                    table.ForeignKey(
                        name: "FK_TPlanetTSystem_Planets_PlanetsId",
                        column: x => x.PlanetsId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TPlanetTSystem_Systems_TSystemId",
                        column: x => x.TSystemId,
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TPlanetTSystem_TSystemId",
                table: "TPlanetTSystem",
                column: "TSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TPlanetTSystem");

            migrationBuilder.DropColumn(
                name: "TSystemId",
                table: "Planets");
        }
    }
}
