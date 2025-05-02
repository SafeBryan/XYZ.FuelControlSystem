using RouteEntity = XYZ.RoutesService.Domain.Route;


namespace XYZ.RoutesService.Application
{
    public class RouteService
    {
        private readonly List<RouteEntity> _routes = new();

        public bool RegisterRoute(string nombre, float distanciaKm, string choferId, string vehiculoId)
        {
            var route = new RouteEntity
            {
                Id = Guid.NewGuid(),
                Nombre = nombre,
                DistanciaKm = distanciaKm,
                ChoferId = choferId,
                VehiculoId = vehiculoId
            };
            _routes.Add(route);
            return true;
        }

        public List<RouteEntity> GetAllRoutes() => _routes;
    }
}