using AirQualityData.API.Entities;
using System.Collections.Generic;

namespace AirQualityData.API.Services
{
    public interface IAirQualityDataRepository
    {
        IEnumerable<Device> GetDevices();
        Device GetDevice(int deviceID);
        void AddDevice(Device device);
        void DeleteDevice(Device device);
        bool DeviceExists(int deviceID);
        bool Save();
    }
}