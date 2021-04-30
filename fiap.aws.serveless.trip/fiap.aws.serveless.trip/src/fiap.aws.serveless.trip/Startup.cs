using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using fiap.aws.serveless.trip.kernell.DomainModel;
using fiap.aws.serveless.trip.kernell.ServiceModel;
using fiap.aws.serveless.trip.Model;
using fiap.aws.serveless.trip.repository;
using fiap.aws.serveless.trip.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace fiap.aws.serveless.trip
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ITripService, TripService>();
            services.AddSingleton<ITripRepository, TripRepository>();
            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TripModel, AddTripRequest>();
                cfg.CreateMap<TripResponse, TripModel>();
                cfg.CreateMap<TripDomain, TripResponse>();
            })
            .CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to Trip API on AWS Lambda");
                });
            });
        }
    }
}
