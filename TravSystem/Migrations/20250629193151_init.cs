using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravSystem.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atmospheres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    HexCode = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atmospheres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    HexCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    HexCode = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LawLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    HexCode = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StellarDensity = table.Column<string>(type: "TEXT", nullable: false),
                    StellerSolo = table.Column<string>(type: "TEXT", nullable: false),
                    StellerBinary = table.Column<string>(type: "TEXT", nullable: false),
                    StellerTrinary = table.Column<string>(type: "TEXT", nullable: false),
                    GasGiantPresent = table.Column<string>(type: "TEXT", nullable: false),
                    GasGiantCount = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanetoidBeltPresent = table.Column<string>(type: "TEXT", nullable: false),
                    PlanetoidBeltCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Starports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    HexCode = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    DieRollMin = table.Column<int>(type: "INTEGER", nullable: false),
                    DieRollMax = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StellarTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    CompanionType = table.Column<string>(type: "TEXT", nullable: false),
                    CompanionSize = table.Column<string>(type: "TEXT", nullable: false),
                    CompanionOrbit = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubSectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradeClassifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Abbreviation = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: true),
                    Atmo = table.Column<string>(type: "TEXT", nullable: true),
                    Hydro = table.Column<string>(type: "TEXT", nullable: true),
                    Population = table.Column<string>(type: "TEXT", nullable: true),
                    Government = table.Column<string>(type: "TEXT", nullable: true),
                    LawLevel = table.Column<string>(type: "TEXT", nullable: true),
                    TechLevel = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeClassifications", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "StellarZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TStellarTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Orbit = table.Column<int>(type: "INTEGER", nullable: false),
                    Zone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StellarZones_StellarTypes_TStellarTypeId",
                        column: x => x.TStellarTypeId,
                        principalTable: "StellarTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TSubSectorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PlanetoidBelts = table.Column<int>(type: "INTEGER", nullable: false),
                    GasGiantCount = table.Column<int>(type: "INTEGER", nullable: false),
                    PopulationModifier = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Systems_SubSectors_TSubSectorId",
                        column: x => x.TSubSectorId,
                        principalTable: "SubSectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    TSubSectorId = table.Column<int>(type: "INTEGER", nullable: true),
                    TSystemId = table.Column<int>(type: "INTEGER", nullable: true),
                    TPlanetId = table.Column<int>(type: "INTEGER", nullable: true),
                    Orbit = table.Column<int>(type: "INTEGER", nullable: false),
                    TStarportId = table.Column<int>(type: "INTEGER", nullable: false),
                    Size = table.Column<int>(type: "INTEGER", nullable: false),
                    TAtmosphereId = table.Column<int>(type: "INTEGER", nullable: false),
                    Hydrographics = table.Column<int>(type: "INTEGER", nullable: false),
                    Population = table.Column<int>(type: "INTEGER", nullable: false),
                    TGovernmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    TLawLevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    TechLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    TravelCodeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planets_Atmospheres_TAtmosphereId",
                        column: x => x.TAtmosphereId,
                        principalTable: "Atmospheres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planets_Governments_TGovernmentId",
                        column: x => x.TGovernmentId,
                        principalTable: "Governments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planets_LawLevels_TLawLevelId",
                        column: x => x.TLawLevelId,
                        principalTable: "LawLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planets_Starports_TStarportId",
                        column: x => x.TStarportId,
                        principalTable: "Starports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planets_SubSectors_TSubSectorId",
                        column: x => x.TSubSectorId,
                        principalTable: "SubSectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Planets_Systems_TSystemId",
                        column: x => x.TSystemId,
                        principalTable: "Systems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Planets_TravelCodes_TravelCodeId",
                        column: x => x.TravelCodeId,
                        principalTable: "TravelCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SystemTBases",
                columns: table => new
                {
                    TSystemId = table.Column<int>(type: "INTEGER", nullable: false),
                    TBaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemTBases", x => new { x.TSystemId, x.TBaseId });
                    table.ForeignKey(
                        name: "FK_SystemTBases_Bases_TBaseId",
                        column: x => x.TBaseId,
                        principalTable: "Bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemTBases_Systems_TSystemId",
                        column: x => x.TSystemId,
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TAtmosphereId",
                table: "Planets",
                column: "TAtmosphereId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TGovernmentId",
                table: "Planets",
                column: "TGovernmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TLawLevelId",
                table: "Planets",
                column: "TLawLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TravelCodeId",
                table: "Planets",
                column: "TravelCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TStarportId",
                table: "Planets",
                column: "TStarportId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TSubSectorId",
                table: "Planets",
                column: "TSubSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TSystemId",
                table: "Planets",
                column: "TSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarZones_TStellarTypeId",
                table: "StellarZones",
                column: "TStellarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Systems_TSubSectorId",
                table: "Systems",
                column: "TSubSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemTBases_TBaseId",
                table: "SystemTBases",
                column: "TBaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "StellarZones");

            migrationBuilder.DropTable(
                name: "SystemTBases");

            migrationBuilder.DropTable(
                name: "TradeClassifications");

            migrationBuilder.DropTable(
                name: "Atmospheres");

            migrationBuilder.DropTable(
                name: "Governments");

            migrationBuilder.DropTable(
                name: "LawLevels");

            migrationBuilder.DropTable(
                name: "Starports");

            migrationBuilder.DropTable(
                name: "TravelCodes");

            migrationBuilder.DropTable(
                name: "StellarTypes");

            migrationBuilder.DropTable(
                name: "Bases");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropTable(
                name: "SubSectors");
        }
    }
}
