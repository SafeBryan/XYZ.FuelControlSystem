using Microsoft.AspNetCore.Mvc;
using Grpc.Net.Client;
using XYZ.VehiclesService.Protos;
using XYZ.ApiGateway.Dtos;

[ApiController]
[Route("api/[controller]")]
public class VehiculosController : ControllerBase
{
    private readonly IConfiguration _config;

    public VehiculosController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VehiclePostDto dto)
    {
        var grpcUrl = _config["GrpcUrls:Vehicles"]!;
        using var channel = GrpcChannel.ForAddress(grpcUrl);
        var client = new VehiclesService.VehiclesServiceClient(channel);

        TipoMaquinaria tipoEnum;

        switch (dto.Tipo.ToLower())
        {
            case "liviana":
                tipoEnum =TipoMaquinaria.Liviana;
                break;
            case "pesada":
                tipoEnum = TipoMaquinaria.Pesada;
                break;
            default:
                return BadRequest($"Tipo de maquinaria inválido: {dto.Tipo}");
        }

        var grpcRequest = new RegisterVehicleRequest
        {
            Placa = dto.Placa,
            Modelo = dto.Modelo,
            Estado = dto.Estado,
            Tipo = tipoEnum
        };

        var result = await client.RegisterVehicleAsync(grpcRequest);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var grpcUrl = _config["GrpcUrls:Vehicles"]!;
        using var channel = GrpcChannel.ForAddress(grpcUrl);
        var client = new VehiclesService.VehiclesServiceClient(channel);

        var result = await client.GetVehiclesAsync(new GetVehiclesRequest());
        return Ok(result.Vehicles);
    }


}
