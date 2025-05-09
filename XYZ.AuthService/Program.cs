using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using XYZ.AuthService.Application;
using XYZ.AuthService.Controllers;
using XYZ.AuthService.Infrastructure;
using XYZ.AuthService.Persistence;

var builder = WebApplication.CreateBuilder(args);

// 👉 1. Configurar EF Core con SQL Server
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDb")));

// 👉 2. Registrar lógica de autenticación
builder.Services.AddScoped<AuthService>();

// 👉 3. Configurar gRPC
builder.Services.AddGrpc();

// 👉 4. Configurar autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// 👉 5. Middleware de autenticación
app.UseAuthentication();
app.UseAuthorization();

// 👉 6. gRPC endpoints
app.MapGrpcService<AuthGrpcService>();
app.MapGet("/", () => "Auth gRPC Service is running.");

// 👉 7. Semilla: usuario admin si no existe
await DataInitializer.SeedAdminUserAsync(app.Services);

// 👉 8. Migración automática (si es primera vez)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
