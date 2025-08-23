using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class SystemFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Roll = table.Column<int>(type: "INTEGER", nullable: false),
                    BasicNature = table.Column<int>(type: "INTEGER", nullable: false),
                    PrimaryType = table.Column<string>(type: "TEXT", nullable: false),
                    PrimarySize = table.Column<string>(type: "TEXT", nullable: false),
                    CompanionType = table.Column<string>(type: "TEXT", nullable: false),
                    CompanionSize = table.Column<string>(type: "TEXT", nullable: false),
                    CompanionOrbit = table.Column<string>(type: "TEXT", nullable: false),
                    MaxOrbits = table.Column<int>(type: "INTEGER", nullable: false),
                    GasGiantPresent = table.Column<bool>(type: "INTEGER", nullable: false),
                    GasGiantQty = table.Column<int>(type: "INTEGER", nullable: false),
                    BeltPresent = table.Column<bool>(type: "INTEGER", nullable: false),
                    BeltQty = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemFeatures", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemFeatures");
        }
    }
}
