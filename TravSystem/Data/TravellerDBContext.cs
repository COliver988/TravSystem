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
        public DbSet<TSettings> Settings { get; set; }
        public DbSet<TStellarTypes> StellarTypes { get; set; }
        public DbSet<TStellarZones> StellarZones { get; set; }

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
            modelBuilder.Entity<TSystem>()
                .HasMany(s => s.Bases)
                .WithMany(b => b.Systems)
                .UsingEntity<TSystemTBases>(
                    j => j
                        .HasOne(pt => pt.TBase)
                        .WithMany(t => t.SystemBases)
                        .HasForeignKey(pt => pt.TBaseId),
                    j => j
                        .HasOne(pt => pt.TSystem)
                        .WithMany(p => p.SystemBases)
                        .HasForeignKey(pt => pt.TSystemId),
                    j =>
                    {
                        j.HasKey(t => new { t.TSystemId, t.TBaseId });
                    });
            modelBuilder.Entity<TStellarTypes>()
                .HasMany(st => st.StellarZones)
                .WithOne(sz => sz.TStellarType)
                .HasForeignKey(sz => sz.TStellarTypeId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Configure delete behavior
        }
    }
}
