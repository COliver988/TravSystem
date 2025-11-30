using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class capturedAndEmpty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapturedAndEmpty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DieRoll = table.Column<int>(type: "INTEGER", nullable: false),
                    Captures = table.Column<bool>(type: "INTEGER", nullable: false),
                    CapturedQty = table.Column<int>(type: "INTEGER", nullable: false),
                    EmptyOrbits = table.Column<bool>(type: "INTEGER", nullable: false),
                    EmptyOrbitsQty = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapturedAndEmpty", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StellarZones_StarTypeId",
                table: "StellarZones",
                column: "StarTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarZones_StarTypes_StarTypeId",
                table: "StellarZones",
                column: "StarTypeId",
                principalTable: "StarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarZones_StarTypes_StarTypeId",
                table: "StellarZones");

            migrationBuilder.DropTable(
                name: "CapturedAndEmpty");

            migrationBuilder.DropIndex(
                name: "IX_StellarZones_StarTypeId",
                table: "StellarZones");
        }
    }
}
