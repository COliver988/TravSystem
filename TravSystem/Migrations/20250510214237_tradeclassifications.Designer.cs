﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyEfCoreApp.Data;

#nullable disable

namespace TravSystem.Migrations
{
    [DbContext(typeof(TravellerDBContext))]
    [Migration("20250510214237_tradeclassifications")]
    partial class tradeclassifications
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("TBaseTPlanet", b =>
                {
                    b.Property<int>("BasesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlanetsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BasesId", "PlanetsId");

                    b.HasIndex("PlanetsId");

                    b.ToTable("TBaseTPlanet");
                });

            modelBuilder.Entity("TravSystem.Models.TAtmosphere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HexCode")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Atmospheres");
                });

            modelBuilder.Entity("TravSystem.Models.TBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HexCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bases");
                });

            modelBuilder.Entity("TravSystem.Models.TGovernment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HexCode")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Governments");
                });

            modelBuilder.Entity("TravSystem.Models.TLawLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HexCode")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LawLevels");
                });

            modelBuilder.Entity("TravSystem.Models.TPlanet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Hydrographics")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Orbit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Population")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TAtmosphereId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TGovernmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TLawLevelId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TPlanetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TStarportId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TSubSectorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TechLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TAtmosphereId");

                    b.HasIndex("TGovernmentId");

                    b.HasIndex("TLawLevelId");

                    b.HasIndex("TStarportId");

                    b.HasIndex("TSubSectorId");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("TravSystem.Models.TPlanetTBases", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("TBaseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TPlanetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PlanetBases");
                });

            modelBuilder.Entity("TravSystem.Models.TStarport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DieRollMax")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DieRollMin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HexCode")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Starports");
                });

            modelBuilder.Entity("TravSystem.Models.TSubSector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SubSectors");
                });

            modelBuilder.Entity("TravSystem.Models.TSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GasGiantCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PlanetoidBelts")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PopulationModifier")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubSectorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SubSectorId");

                    b.ToTable("Systems");
                });

            modelBuilder.Entity("TravSystem.Models.TradeClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Atmo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Government")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Hydro")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LawLevel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Population")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TechLevel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TradeClassifications");
                });

            modelBuilder.Entity("TBaseTPlanet", b =>
                {
                    b.HasOne("TravSystem.Models.TBase", null)
                        .WithMany()
                        .HasForeignKey("BasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravSystem.Models.TPlanet", null)
                        .WithMany()
                        .HasForeignKey("PlanetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravSystem.Models.TPlanet", b =>
                {
                    b.HasOne("TravSystem.Models.TAtmosphere", "Atmosphere")
                        .WithMany()
                        .HasForeignKey("TAtmosphereId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TravSystem.Models.TGovernment", "Government")
                        .WithMany()
                        .HasForeignKey("TGovernmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TravSystem.Models.TLawLevel", "LawLevel")
                        .WithMany()
                        .HasForeignKey("TLawLevelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TravSystem.Models.TStarport", "Starport")
                        .WithMany()
                        .HasForeignKey("TStarportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TravSystem.Models.TSubSector", "SubSector")
                        .WithMany()
                        .HasForeignKey("TSubSectorId");

                    b.Navigation("Atmosphere");

                    b.Navigation("Government");

                    b.Navigation("LawLevel");

                    b.Navigation("Starport");

                    b.Navigation("SubSector");
                });

            modelBuilder.Entity("TravSystem.Models.TSystem", b =>
                {
                    b.HasOne("TravSystem.Models.TSubSector", "SubSector")
                        .WithMany()
                        .HasForeignKey("SubSectorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SubSector");
                });
#pragma warning restore 612, 618
        }
    }
}
