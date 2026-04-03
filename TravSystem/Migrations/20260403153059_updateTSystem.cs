using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class updateTSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StarTypeIds",
                table: "Systems",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "TSystemId",
                table: "StarTypes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StarTypes_TSystemId",
                table: "StarTypes",
                column: "TSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_StarTypes_Systems_TSystemId",
                table: "StarTypes",
                column: "TSystemId",
                principalTable: "Systems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StarTypes_Systems_TSystemId",
                table: "StarTypes");

            migrationBuilder.DropIndex(
                name: "IX_StarTypes_TSystemId",
                table: "StarTypes");

            migrationBuilder.DropColumn(
                name: "StarTypeIds",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "TSystemId",
                table: "StarTypes");
        }
    }
}
