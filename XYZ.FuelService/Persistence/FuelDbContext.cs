using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using XYZ.FuelService.Domain;

namespace XYZ.FuelService.Persistence
{
    public class FuelDbContext : DbContext
    {
        public FuelDbContext(DbContextOptions<FuelDbContext> options) : base(options) { }
        public DbSet<FuelRecord> FuelRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuelRecord>().ToTable("FuelRecords");
        }
    }
}
