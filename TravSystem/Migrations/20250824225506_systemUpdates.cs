using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class systemUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BasicNature",
                table: "Systems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TStellarTypeIds",
                table: "Systems",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "TSystemId",
                table: "StellarTypes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StellarTypes_TSystemId",
                table: "StellarTypes",
                column: "TSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarTypes_Systems_TSystemId",
                table: "StellarTypes",
                column: "TSystemId",
                principalTable: "Systems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarTypes_Systems_TSystemId",
                table: "StellarTypes");

            migrationBuilder.DropIndex(
                name: "IX_StellarTypes_TSystemId",
                table: "StellarTypes");

            migrationBuilder.DropColumn(
                name: "BasicNature",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "TStellarTypeIds",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "TSystemId",
                table: "StellarTypes");
        }
    }
}
