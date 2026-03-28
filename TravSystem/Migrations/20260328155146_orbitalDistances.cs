using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class orbitalDistances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrbitalDistances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Orbit = table.Column<int>(type: "INTEGER", nullable: false),
                    AU = table.Column<decimal>(type: "TEXT", nullable: false),
                    Kilometers = table.Column<float>(type: "REAL", nullable: false),
                    SolarRadii = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrbitalDistances", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StellarData_StarTypeId",
                table: "StellarData",
                column: "StarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarData_StellarTypeId",
                table: "StellarData",
                column: "StellarTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarData_StarTypes_StarTypeId",
                table: "StellarData",
                column: "StarTypeId",
                principalTable: "StarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarData_StellarTypes_StellarTypeId",
                table: "StellarData",
                column: "StellarTypeId",
                principalTable: "StellarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarData_StarTypes_StarTypeId",
                table: "StellarData");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarData_StellarTypes_StellarTypeId",
                table: "StellarData");

            migrationBuilder.DropTable(
                name: "OrbitalDistances");

            migrationBuilder.DropIndex(
                name: "IX_StellarData_StarTypeId",
                table: "StellarData");

            migrationBuilder.DropIndex(
                name: "IX_StellarData_StellarTypeId",
                table: "StellarData");
        }
    }
}
