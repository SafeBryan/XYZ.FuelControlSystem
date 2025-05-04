using Microsoft.EntityFrameworkCore;
using XYZ.RoutesService.Domain;

namespace XYZ.RoutesService.Infrastructure
{
    public class RouteDbContext : DbContext
    {
        public DbSet<Domain.Route> Routes { get; set; }

        public RouteDbContext(DbContextOptions<RouteDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Route>().ToTable("Routes");
        }
    }
}

