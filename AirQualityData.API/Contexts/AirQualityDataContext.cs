using AirQualityData.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityData.API.Contexts
{
    public class AirQualityDataContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public AirQualityDataContext(DbContextOptions<AirQualityDataContext> options) : base(options)
        {
        }
    }
}
