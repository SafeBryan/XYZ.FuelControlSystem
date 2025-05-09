using Grpc.Core;
using XYZ.DriversService.Application;
using XYZ.DriversService.Domain;
using XYZ.DriversService.Protos;

namespace XYZ.DriversService.Controllers
{
    public class DriverGrpcService : Protos.DriversService.DriversServiceBase
    {
        private readonly DriverService _driverService;

        public DriverGrpcService(DriverService driverService)
        {
            _driverService = driverService;
        }

        public override async Task<RegisterDriverResponse> RegisterDriver(RegisterDriverRequest request, ServerCallContext context)
        {
            var success = await _driverService.RegisterDriver(request.Name, request.LicenseNumber);

            return new RegisterDriverResponse { Success = success };
        }

        public override async Task<GetDriversResponse> GetDrivers(GetDriversRequest request, ServerCallContext context)
        {
            var list = await _driverService.GetAllDrivers();

            var response = new GetDriversResponse();
            foreach (var d in list)
            {
                response.Drivers.Add(new DriverMessage
                {
                    Id = d.Id.ToString(),
                    Name = d.Name,
                    LicenseNumber = d.LicenseNumber
                });
            }

            return response;
        }
    }
}
