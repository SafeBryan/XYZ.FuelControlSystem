using XYZ.DriversService.Domain;
using XYZ.DriversService.Persistence;
using Microsoft.EntityFrameworkCore;

namespace XYZ.DriversService.Application
{
    public class DriverService
    {
        private readonly DriverDbContext _context;

        public DriverService(DriverDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterDriver(string name, string license)
        {
            var driver = new Driver
            {
                Id = Guid.NewGuid(),
                Name = name,
                LicenseNumber = license
            };

            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Driver>> GetAllDrivers()
        {
            return await _context.Drivers.ToListAsync();
        }
    }
}
