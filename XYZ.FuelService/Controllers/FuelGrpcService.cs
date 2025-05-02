using Grpc.Core;
using XYZ.FuelService.Application;
using Domain = XYZ.FuelService.Domain;
using Protos = XYZ.FuelService.Protos;

namespace XYZ.FuelService.Controllers
{
    public class FuelGrpcService : Protos.FuelService.FuelServiceBase
    {
        private readonly Application.FuelService _fuelService;

        public FuelGrpcService(Application.FuelService fuelService)
        {
            _fuelService = fuelService;
        }

        public override async Task<Protos.RegisterFuelUsageResponse> RegisterFuelUsage(Protos.RegisterFuelUsageRequest request, ServerCallContext context)
        {
            var tipo = request.Tipo == Protos.TipoMaquinaria.Liviana
                ? Domain.TipoMaquinaria.Liviana
                : Domain.TipoMaquinaria.Pesada;

            var success = await _fuelService.RegistrarConsumo(request.VehiculoId, request.RutaId, request.LitrosConsumidos, tipo);

            return new Protos.RegisterFuelUsageResponse { Success = success };
        }

        public override async Task<Protos.FuelReportResponse> GetFuelReport(Protos.FuelReportRequest request, ServerCallContext context)
        {
            var tipo = request.Tipo == Protos.TipoMaquinaria.Liviana
                ? Domain.TipoMaquinaria.Liviana
                : Domain.TipoMaquinaria.Pesada;

            var registros = await _fuelService.ObtenerReportePorTipo(tipo);

            var response = new Protos.FuelReportResponse();
            foreach (var r in registros)
            {
                response.Items.Add(new Protos.FuelReportItemMessage
                {
                    VehiculoId = r.VehiculoId,
                    LitrosTotales = r.LitrosConsumidos
                });
            }

            return response;
        }
    }
}
