using Microsoft.EntityFrameworkCore;
using XYZ.VehiclesService.Application;
using XYZ.VehiclesService.Controllers;
using XYZ.VehiclesService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ✅ EF Core
builder.Services.AddDbContext<VehicleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VehicleDb")));

// ✅ Servicios
builder.Services.AddScoped<VehicleService>();
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

var app = builder.Build();

// ✅ Migración automática
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<VehicleDbContext>();
    db.Database.Migrate();
}

app.MapGrpcService<VehicleGrpcService>();
app.MapGrpcReflectionService();
app.MapGet("/", () => "gRPC Vehicles Service activo");

app.Run();
