using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class addedStarTypeToZones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StarType",
                table: "StellarZones",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarType",
                table: "StellarZones");
        }
    }
}
