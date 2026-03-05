using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class stellardata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mass",
                table: "StellarTypes");

            migrationBuilder.CreateTable(
                name: "StellarData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StarTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    StellarTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Magnitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    Luminosity = table.Column<decimal>(type: "TEXT", nullable: false),
                    Temperature = table.Column<int>(type: "INTEGER", nullable: false),
                    Radius = table.Column<decimal>(type: "TEXT", nullable: false),
                    Mass = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StellarData");

            migrationBuilder.AddColumn<decimal>(
                name: "Mass",
                table: "StellarTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
