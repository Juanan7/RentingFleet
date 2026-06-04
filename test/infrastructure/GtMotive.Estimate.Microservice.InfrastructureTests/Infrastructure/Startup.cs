using GtMotive.Estimate.Microservice.Api;
using GtMotive.Estimate.Microservice.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    internal sealed class Startup(IWebHostEnvironment environment, IConfiguration configuration)
    {
        public IWebHostEnvironment Environment { get; } = environment;

        public IConfiguration Configuration { get; } = configuration;

        public static void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(ApiConfiguration.ConfigureControllers)
                .WithApiControllers();

            services.AddBaseInfrastructure(true);
        }
    }
}
