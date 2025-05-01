using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class planetName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planets_Atmospheres_TAtmosphereId",
                table: "Planets");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Planets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Systems_SubSectorId",
                table: "Systems",
                column: "SubSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TGovernmentId",
                table: "Planets",
                column: "TGovernmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TLawLevelId",
                table: "Planets",
                column: "TLawLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TStarportId",
                table: "Planets",
                column: "TStarportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_Atmospheres_TAtmosphereId",
                table: "Planets",
                column: "TAtmosphereId",
                principalTable: "Atmospheres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_Governments_TGovernmentId",
                table: "Planets",
                column: "TGovernmentId",
                principalTable: "Governments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_LawLevels_TLawLevelId",
                table: "Planets",
                column: "TLawLevelId",
                principalTable: "LawLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_Starports_TStarportId",
                table: "Planets",
                column: "TStarportId",
                principalTable: "Starports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Systems_SubSectors_SubSectorId",
                table: "Systems",
                column: "SubSectorId",
                principalTable: "SubSectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planets_Atmospheres_TAtmosphereId",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_Planets_Governments_TGovernmentId",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_Planets_LawLevels_TLawLevelId",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_Planets_Starports_TStarportId",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_Systems_SubSectors_SubSectorId",
                table: "Systems");

            migrationBuilder.DropIndex(
                name: "IX_Systems_SubSectorId",
                table: "Systems");

            migrationBuilder.DropIndex(
                name: "IX_Planets_TGovernmentId",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Planets_TLawLevelId",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Planets_TStarportId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Planets");

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_Atmospheres_TAtmosphereId",
                table: "Planets",
                column: "TAtmosphereId",
                principalTable: "Atmospheres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
