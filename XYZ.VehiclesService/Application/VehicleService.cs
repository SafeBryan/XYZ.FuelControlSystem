using XYZ.VehiclesService.Domain;
using XYZ.VehiclesService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace XYZ.VehiclesService.Application
{
    public class VehicleService
    {
        private readonly VehicleDbContext _context;

        public VehicleService(VehicleDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterVehicle(string placa, string modelo, string estado, string tipo)
        {
            if (!Enum.TryParse<Protos.TipoMaquinaria>(tipo, true, out var tipoProto))
            {
                Console.WriteLine($"Error: El tipo de maquinaria '{tipo}' no es válido.");
                return false;
            }

            var tipoMaquinaria = (TipoMaquinaria)(int)tipoProto;

            var vehicle = new VehicleEntity
            {
                Id = Guid.NewGuid(),
                Placa = placa,
                Modelo = modelo,
                Estado = estado,
                Tipo = tipoMaquinaria
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<VehicleEntity>> GetAllVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }
    }
}
