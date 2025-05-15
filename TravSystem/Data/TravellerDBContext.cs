using Microsoft.EntityFrameworkCore;
using TravSystem.Models;

namespace MyEfCoreApp.Data
{
    public class TravellerDBContext : DbContext
    {
        public DbSet<TSystem> Systems { get; set; }
        public DbSet<TAtmosphere> Atmospheres { get; set; }
        public DbSet<TLawLevel> LawLevels { get; set; }
        public DbSet<TPlanet> Planets { get; set; }
        public DbSet<TStarport> Starports { get; set; }
        public DbSet<TSubSector> SubSectors { get; set; }
        public DbSet<TGovernment> Governments { get; set; }
        public DbSet<TBase> Bases { get; set; }
        public DbSet<TSystemTBases> SystemTBases { get; set; }
        public DbSet<TradeClassification> TradeClassifications { get; set; }
        public DbSet<TTravelCode> TravelCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Traveller.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TPlanet>()
                .HasOne(p => p.LawLevel)
                .WithMany()
                .HasForeignKey(p => p.TLawLevelId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TPlanet>()
                .HasOne(p => p.Atmosphere) // Navigation property
                .WithMany()                // Assuming TAtmosphere does not have a collection of TPlanets
                .HasForeignKey(p => p.TAtmosphereId) // Foreign key
                .OnDelete(DeleteBehavior.Restrict); // Optional: Configure delete behavior
            modelBuilder.Entity<TPlanet>()
                .HasOne(p => p.Starport) // Navigation property
                .WithMany()                // Assuming TAtmosphere does not have a collection of TPlanets
                .HasForeignKey(p => p.TStarportId) // Foreign key
                .OnDelete(DeleteBehavior.Restrict); // Optional: Configure delete behavior
            modelBuilder.Entity<TPlanet>()
                .HasOne(p => p.Government) // Navigation property
                .WithMany()                // Assuming TAtmosphere does not have a collection of TPlanets
                .HasForeignKey(p => p.TGovernmentId) // Foreign key
                .OnDelete(DeleteBehavior.Restrict); // Optional: Configure delete behavior
            modelBuilder.Entity<TPlanet>()
                .HasOne(p => p.TravelCode)
                .WithMany()
                .HasForeignKey(p => p.TravelCodeId);
            modelBuilder.Entity<TSystem>()
                .HasOne(s => s.SubSector)
                .WithMany()
                .HasForeignKey(p => p.SubSectorId);
        }
    }
}
