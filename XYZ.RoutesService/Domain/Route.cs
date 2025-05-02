namespace XYZ.RoutesService.Domain
{
    public class Route
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public float DistanciaKm { get; set; }
        public string ChoferId { get; set; }
        public string VehiculoId { get; set; }
    }
}
