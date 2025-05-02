using XYZ.DriversService.Domain;

namespace XYZ.DriversService.Application
{
    public class DriverService
    {
        private readonly List<Driver> _drivers = new();

        public bool RegisterDriver(string name, string license)
        {
            var driver = new Driver
            {
                Id = Guid.NewGuid(),
                Name = name,
                LicenseNumber = license
            };
            _drivers.Add(driver);
            return true;
        }

        public List<Driver> GetAllDrivers()
        {
            return _drivers;
        }
    }
}
