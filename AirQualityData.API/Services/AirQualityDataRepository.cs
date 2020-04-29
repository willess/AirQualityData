using AirQualityData.API.Contexts;
using AirQualityData.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityData.API.Services
{
    public class AirQualityDataRepository : IAirQualityDataRepository
    {
        private readonly AirQualityDataContext _context;

        public AirQualityDataRepository(AirQualityDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Device> GetDevices()
        {
            return _context.Devices.ToList();
        }

        public Device GetDevice(int deviceID)
        {
            return _context.Devices.Where(d => d.Id == deviceID).FirstOrDefault();
        }

        public void AddDevice(Device device)
        {
            _context.Devices.Add(device);
        }
        public void DeleteDevice(Device device)
        {
            _context.Devices.Remove(device);
        }

        public bool DeviceExists(int deviceID)
        {
            return _context.Devices.Any(d => d.Id == deviceID);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
