using System.Threading.Tasks;
using Grpc.Core;
using XYZ.DriversService.Application;
using XYZ.DriversService.Domain;
using XYZ.DriversService.Protos; 

namespace XYZ.DriversService.Controllers
{
    public class DriverGrpcService : Protos.DriversService.DriversServiceBase 
    {
        private readonly DriverService _driverService;

        public DriverGrpcService()
        {
            _driverService = new DriverService();
        }

        public override Task<RegisterDriverResponse> RegisterDriver(RegisterDriverRequest request, ServerCallContext context)
        {
            var success = _driverService.RegisterDriver(request.Name, request.LicenseNumber);

            return Task.FromResult(new RegisterDriverResponse
            {
                Success = success
            });
        }

        public override Task<GetDriversResponse> GetDrivers(GetDriversRequest request, ServerCallContext context)
        {
            //var driversList = _driverService.GetAllDrivers();

            var response = new GetDriversResponse();
           /* foreach (var d in driversList)
            {
                response.Drivers.Add(new DriverMessage
                {
                    Id = d.Id.ToString(),
                    Name = d.Name,
                    LicenseNumber = d.LicenseNumber
                });
            }*/

            response.Drivers.Add(new DriverMessage
            {
                Id = "1",
                LicenseNumber = "1",
                Name = "Bryan",
            });
            return Task.FromResult(response);

        }
    }
}
