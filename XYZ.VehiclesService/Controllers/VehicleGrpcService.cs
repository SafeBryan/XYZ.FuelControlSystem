using Grpc.Core;
using XYZ.VehiclesService.Application;
using XYZ.VehiclesService.Domain;
using XYZ.VehiclesService.Protos;

namespace XYZ.VehiclesService.Controllers
{
    public class VehicleGrpcService : Protos.VehiclesService.VehiclesServiceBase
    {
        private readonly VehicleService _vehicleService = new();

        public override Task<RegisterVehicleResponse> RegisterVehicle(RegisterVehicleRequest request, ServerCallContext context)
        {
            var success = _vehicleService.RegisterVehicle(
                request.Placa,
                request.Modelo,
                request.Estado,
                request.Tipo.ToString()
            );

            return Task.FromResult(new RegisterVehicleResponse
            {
                Success = success
            });
        }

        public override Task<GetVehiclesResponse> GetVehicles(GetVehiclesRequest request, ServerCallContext context)
        {
            var vehicles = _vehicleService.GetAllVehicles();
            var response = new GetVehiclesResponse();

            foreach (var v in vehicles)
            {
                response.Vehicles.Add(new VehicleMessage
                {
                    Id = v.Id.ToString(),
                    Placa = v.Placa,
                    Modelo = v.Modelo,
                    Estado = v.Estado,
                    Tipo = (Protos.TipoMaquinaria)(int)v.Tipo
                });
            }

            return Task.FromResult(response);
        }
    }
}
