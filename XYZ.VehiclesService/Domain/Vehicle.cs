namespace XYZ.VehiclesService.Domain
{
    public enum TipoMaquinaria
    {
        LIVIANA = 0,
        PESADA = 1
    }

    public class VehicleEntity
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }=" ";
        public string Modelo { get; set; }=" ";
        public string Estado { get; set; }=" ";
        public TipoMaquinaria Tipo { get; set; }
    }
}
