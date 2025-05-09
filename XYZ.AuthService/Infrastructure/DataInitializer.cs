using XYZ.AuthService.Domain;
using Microsoft.EntityFrameworkCore;
using XYZ.AuthService.Persistence;

namespace XYZ.AuthService.Infrastructure
{
    public class DataInitializer
    {
        public static async Task SeedAdminUserAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AuthDbContext>();

            await context.Database.MigrateAsync();

            if (!await context.Users.AnyAsync(u => u.Username == "admin"))
            {
                context.Users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Username = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    Rol = Rol.ADMIN
                });

                await context.SaveChangesAsync();
                Console.WriteLine("✅ Usuario admin creado");
            }
        }
    }
}
