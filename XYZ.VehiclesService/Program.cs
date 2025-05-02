using Grpc.Reflection;
using Grpc.Reflection.V1Alpha;

namespace XYZ.VehiclesService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Registrar servicios gRPC y reflexión
            builder.Services.AddGrpc();
            builder.Services.AddGrpcReflection(); // ? esto es nuevo

            var app = builder.Build();

            app.MapGrpcService<XYZ.VehiclesService.Controllers.VehicleGrpcService>();
            app.MapGrpcReflectionService(); // ? esto es nuevo
            app.MapGet("/", () => "Use a gRPC client to communicate with gRPC endpoints.");

            app.Run();
        }
    }
}
