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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Traveller.db");
        }
    }
}
