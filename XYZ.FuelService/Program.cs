using Microsoft.EntityFrameworkCore;
using XYZ.FuelService.Controllers;
using XYZ.FuelService.Infrastructure;
using XYZ.FuelService.Persistence;
using FuelApp = XYZ.FuelService.Application;

namespace XYZ.FuelService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 🔐 1. Configurar DbContext
            builder.Services.AddDbContext<FuelDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FuelDb")));

            // 🔐 2. Registrar servicios de aplicación y el interceptor
            builder.Services.AddScoped<FuelApp.FuelService>();
            builder.Services.AddScoped<JwtInterceptor>();

            // 🔐 3. Configurar gRPC con interceptor JWT
            builder.Services.AddGrpc(options =>
            {
                options.Interceptors.Add<JwtInterceptor>();
            });

            var app = builder.Build();

            // ✅ 4. Aplicar migraciones automáticas
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<FuelDbContext>();
                dbContext.Database.Migrate();
            }

            // ✅ 5. Mapear servicios gRPC
            app.MapGrpcService<FuelGrpcService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

            app.Run();
        }
    }
}
