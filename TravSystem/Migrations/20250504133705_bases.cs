using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class bases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GasGiantCount",
                table: "Systems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanetoidBelts",
                table: "Systems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PopulationModifier",
                table: "Systems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    HexCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanetBases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TPlanetId = table.Column<int>(type: "INTEGER", nullable: false),
                    TBaseId = table.Column<int>(type: "INTEGER", nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanetBases");

            migrationBuilder.DropTable(
                name: "TBaseTPlanet");

            migrationBuilder.DropTable(
                name: "Bases");

            migrationBuilder.DropColumn(
                name: "GasGiantCount",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "PlanetoidBelts",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "PopulationModifier",
                table: "Systems");
        }
    }
}
