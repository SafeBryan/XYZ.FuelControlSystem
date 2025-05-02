using XYZ.FuelService.Domain;
using XYZ.FuelService.Persistence;
using Microsoft.EntityFrameworkCore;

namespace XYZ.FuelService.Application
{
    public class FuelService
    {
        private readonly FuelDbContext _context;

        public FuelService(FuelDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarConsumo(string vehiculoId, string rutaId, float litros, TipoMaquinaria tipo)
        {
            var record = new FuelRecord
            {
                Id = Guid.NewGuid(),
                VehiculoId = vehiculoId,
                RutaId = rutaId,
                LitrosConsumidos = litros,
                Tipo = tipo,
                FechaRegistro = DateTime.UtcNow
            };
            _context.FuelRecords.Add(record);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<FuelRecord>> ObtenerReportePorTipo(TipoMaquinaria tipo)
        {
            return await _context.FuelRecords
                .Where(f => f.Tipo == tipo)
                .ToListAsync();
        }
    }
}
