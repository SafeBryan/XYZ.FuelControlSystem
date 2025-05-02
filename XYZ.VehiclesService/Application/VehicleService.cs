using XYZ.VehiclesService.Domain;
using XYZ.VehiclesService;

namespace XYZ.VehiclesService.Application
{
    public class VehicleService
    {
        private readonly List<VehicleEntity> _vehicles = new();

        public bool RegisterVehicle(string placa, string modelo, string estado, string tipo)
        {
            if (!Enum.TryParse<Protos.TipoMaquinaria>(tipo, true, out var tipoProto))
            {
                Console.WriteLine($"Error: El tipo de maquinaria '{tipo}' no es válido.");
                return false;
            }

            var tipoMaquinaria = (Domain.TipoMaquinaria)(int)tipoProto;

            var vehicle = new VehicleEntity
            {
                Id = Guid.NewGuid(),
                Placa = placa,
                Modelo = modelo,
                Estado = estado,
                Tipo = tipoMaquinaria
            };

            _vehicles.Add(vehicle);
            return true;
        }

        public List<VehicleEntity> GetAllVehicles() => _vehicles;
    }
}
