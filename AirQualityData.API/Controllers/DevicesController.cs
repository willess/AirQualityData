using AirQualityData.API.Entities;
using AirQualityData.API.Models;
using AirQualityData.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityData.API.Controllers
{
    // routing
    [ApiController]
    [Route("api/airqualitydata")]

    public class DevicesController : ControllerBase
    {
        private readonly IAirQualityDataRepository _airQualityDataRepository;

        public DevicesController(IAirQualityDataRepository airQualityDataRepository)
        {
            _airQualityDataRepository = airQualityDataRepository ?? throw new ArgumentNullException(nameof(airQualityDataRepository));
        }

        //get all
        [HttpGet]
        public IActionResult GetDevices()
        {
            // return a list of all devices
            var devices = _airQualityDataRepository.GetDevices();

            return Ok(devices);
        }

        // get 1
        [HttpGet("{id}")]
        public IActionResult GetDevice(int id)
        {
            if(!_airQualityDataRepository.DeviceExists(id))
            {
                return NotFound();
            }

            var device = _airQualityDataRepository.GetDevice(id);

            return Ok(device);
        }

        // Create
        [HttpPost]
        public IActionResult CreateDevice([FromBody] DeviceForCreationDto device)
        {
            // check if input data is valid
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newDevice = new Device
            {
                Name = device.Name,
                Location = device.Location
            };

            _airQualityDataRepository.AddDevice(newDevice);

            _airQualityDataRepository.Save();

            return Ok($"New Device has been Successfully created: {newDevice.Name} in {newDevice.Location}");
        }

        // Update
        //[HttpPut("{id}")]

        // Patch
        //[HttpPatch("{id}")]

        // Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteDevice(int id)
        {
            if (!_airQualityDataRepository.DeviceExists(id))
            {
                return NotFound();
            }

            var device = _airQualityDataRepository.GetDevice(id);

            _airQualityDataRepository.DeleteDevice(device);

            _airQualityDataRepository.Save();

            return NoContent();
        }

    }
}
