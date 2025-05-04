using Microsoft.EntityFrameworkCore;
using XYZ.VehiclesService.Domain;

namespace XYZ.VehiclesService.Infrastructure
{
    public class VehicleDbContext : DbContext
    {
        public DbSet<VehicleEntity> Vehicles { get; set; }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleEntity>().ToTable("Vehicles");
        }
    }
}
