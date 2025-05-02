namespace XYZ.FuelService.Domain
{
    public enum TipoMaquinaria
    {
        Liviana = 0,
        Pesada = 1
    }


    public class FuelRecord
    {
        public Guid Id { get; set; }
        public string VehiculoId { get; set; }
        public string RutaId { get; set; }
        public float LitrosConsumidos { get; set; }
        public TipoMaquinaria Tipo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
