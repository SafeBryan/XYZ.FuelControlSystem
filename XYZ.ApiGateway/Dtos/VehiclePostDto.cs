namespace XYZ.ApiGateway.Dtos
{
    public class VehiclePostDto
    {
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty; // "Liviana" o "Pesada"
    }
}
