using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class updatePlanet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TechLevelID",
                table: "Planets",
                newName: "TechLevel");

            migrationBuilder.RenameColumn(
                name: "SubSectorId",
                table: "Planets",
                newName: "TSubSectorId");

            migrationBuilder.RenameColumn(
                name: "StarportID",
                table: "Planets",
                newName: "TStarportId");

            migrationBuilder.RenameColumn(
                name: "PlanetId",
                table: "Planets",
                newName: "TPlanetId");

            migrationBuilder.RenameColumn(
                name: "LawLevelID",
                table: "Planets",
                newName: "TLawLevelId");

            migrationBuilder.RenameColumn(
                name: "HydrographicsID",
                table: "Planets",
                newName: "TGovernmentId");

            migrationBuilder.RenameColumn(
                name: "GovernmentID",
                table: "Planets",
                newName: "TAtmosphereId");

            migrationBuilder.RenameColumn(
                name: "AtmosphereID",
                table: "Planets",
                newName: "Hydrographics");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TAtmosphereId",
                table: "Planets",
                column: "TAtmosphereId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_Atmospheres_TAtmosphereId",
                table: "Planets",
                column: "TAtmosphereId",
                principalTable: "Atmospheres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planets_Atmospheres_TAtmosphereId",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Planets_TAtmosphereId",
                table: "Planets");

            migrationBuilder.RenameColumn(
                name: "TechLevel",
                table: "Planets",
                newName: "TechLevelID");

            migrationBuilder.RenameColumn(
                name: "TSubSectorId",
                table: "Planets",
                newName: "SubSectorId");

            migrationBuilder.RenameColumn(
                name: "TStarportId",
                table: "Planets",
                newName: "StarportID");

            migrationBuilder.RenameColumn(
                name: "TPlanetId",
                table: "Planets",
                newName: "PlanetId");

            migrationBuilder.RenameColumn(
                name: "TLawLevelId",
                table: "Planets",
                newName: "LawLevelID");

            migrationBuilder.RenameColumn(
                name: "TGovernmentId",
                table: "Planets",
                newName: "HydrographicsID");

            migrationBuilder.RenameColumn(
                name: "TAtmosphereId",
                table: "Planets",
                newName: "GovernmentID");

            migrationBuilder.RenameColumn(
                name: "Hydrographics",
                table: "Planets",
                newName: "AtmosphereID");
        }
    }
}
