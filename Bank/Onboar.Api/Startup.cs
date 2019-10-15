using System;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Onboar.Api.BusConfigs.Consumers;
using Onboar.Api.BusConfigs.HostedServices;
using Onboar.Api.Model;

namespace Onboar.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<CustomerConsumer>();
                cfg.AddBus(ConfigureBus);
                cfg.AddRequestClient<ICustomer>();
            });

            services.AddSingleton<IHostedService, MassTransitHostedService>();
            services.AddSingleton<IHostedService, CustomerHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        public IBusControl ConfigureBus(IServiceProvider provider)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("amqp://guest:guest@localhost:5672/"), h => { });
                cfg.ConfigureEndpoints(provider);
            });
        }
    }
}
