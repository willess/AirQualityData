using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQualityData.API.Contexts;
using AirQualityData.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AirQualityData.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Services dependency injection
            // Adding MVC
            services.AddMvc();

            // Register db context and connect to the database
            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=AirQualityDataDB;Trusted_Connection=True;";
            services.AddDbContext<AirQualityDataContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

            services.AddScoped<IAirQualityDataRepository, AirQualityDataRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            else
            {
                app.UseExceptionHandler("/Error");
            }

            // Status Code middleware
            app.UseStatusCodePages();

            app.UseMvc();
        }
    }
}
