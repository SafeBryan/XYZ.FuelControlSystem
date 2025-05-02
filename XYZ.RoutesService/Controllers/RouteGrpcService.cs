using Grpc.Core;
using XYZ.RoutesService.Application;
using XYZ.RoutesService.Protos;

namespace XYZ.RoutesService.Controllers
{
    public class RouteGrpcService : Protos.RoutesService.RoutesServiceBase
    {
        private readonly RouteService _routeService = new();

        public override Task<RegisterRouteResponse> RegisterRoute(RegisterRouteRequest request, ServerCallContext context)
        {
            var success = _routeService.RegisterRoute(request.Nombre, request.DistanciaKm, request.ChoferId, request.VehiculoId);
            return Task.FromResult(new RegisterRouteResponse { Success = success });
        }

        public override Task<GetRoutesResponse> GetRoutes(GetRoutesRequest request, ServerCallContext context)
        {
            var routes = _routeService.GetAllRoutes();
            var response = new GetRoutesResponse();

            foreach (var r in routes)
            {
                response.Routes.Add(new RouteMessage
                {
                    Id = r.Id.ToString(),
                    Nombre = r.Nombre,
                    DistanciaKm = r.DistanciaKm,
                    ChoferId = r.ChoferId,
                    VehiculoId = r.VehiculoId
                });
            }

            return Task.FromResult(response);
        }
    }
}
