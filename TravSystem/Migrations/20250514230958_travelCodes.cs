using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class travelCodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TravelCodeId",
                table: "Planets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TravelCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelCodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TravelCodeId",
                table: "Planets",
                column: "TravelCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_TravelCodes_TravelCodeId",
                table: "Planets",
                column: "TravelCodeId",
                principalTable: "TravelCodes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planets_TravelCodes_TravelCodeId",
                table: "Planets");

            migrationBuilder.DropTable(
                name: "TravelCodes");

            migrationBuilder.DropIndex(
                name: "IX_Planets_TravelCodeId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "TravelCodeId",
                table: "Planets");
        }
    }
}
