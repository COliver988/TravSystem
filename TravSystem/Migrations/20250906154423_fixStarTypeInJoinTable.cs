using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class fixStarTypeInJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarType",
                table: "StellarZones");

            migrationBuilder.AddColumn<int>(
                name: "StarTypeId",
                table: "StellarZones",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarTypeId",
                table: "StellarZones");

            migrationBuilder.AddColumn<string>(
                name: "StarType",
                table: "StellarZones",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
