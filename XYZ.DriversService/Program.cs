using Microsoft.EntityFrameworkCore;
using XYZ.DriversService.Application;
using XYZ.DriversService.Controllers;
using XYZ.DriversService.Persistence;
using XYZ.DriversService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ✅ EF Core
builder.Services.AddDbContext<DriverDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DriverDb")));

// ✅ App logic + Interceptor
builder.Services.AddScoped<DriverService>();
builder.Services.AddScoped<JwtInterceptor>();

builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<JwtInterceptor>();
});

var app = builder.Build();

// ✅ Migración automática
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DriverDbContext>();
    db.Database.Migrate();
}

app.MapGrpcService<DriverGrpcService>();
app.MapGet("/", () => "gRPC Drivers Service activo");

app.Run();
