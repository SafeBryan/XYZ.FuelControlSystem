using Microsoft.EntityFrameworkCore;
using XYZ.AuthService.Domain;

namespace XYZ.VehiclesService.Infrastructure
{
    public class VehicleDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
