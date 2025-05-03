using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class starportTableDieRange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DieRollMax",
                table: "Starports",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DieRollMin",
                table: "Starports",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TSubSectorId",
                table: "Planets",
                column: "TSubSectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_SubSectors_TSubSectorId",
                table: "Planets",
                column: "TSubSectorId",
                principalTable: "SubSectors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planets_SubSectors_TSubSectorId",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Planets_TSubSectorId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "DieRollMax",
                table: "Starports");

            migrationBuilder.DropColumn(
                name: "DieRollMin",
                table: "Starports");
        }
    }
}
