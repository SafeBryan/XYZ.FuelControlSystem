using XYZ.DriversService.Domain;
using Microsoft.EntityFrameworkCore;


namespace XYZ.DriversService.Persistence
{
        public class DriverDbContext : DbContext
        {
            public DbSet<Driver> Drivers { get; set; }

            public DriverDbContext(DbContextOptions<DriverDbContext> options)
                : base(options) { }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Driver>().ToTable("Drivers");
            }
        }
}
