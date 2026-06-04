using System;
using System.Net.Http;
using GtMotive.Estimate.Microservice.Api;
using GtMotive.Estimate.Microservice.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    public sealed class GenericInfrastructureTestServerFixture : IDisposable
    {
        private readonly TestServer _server;

        public GenericInfrastructureTestServerFixture()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .ConfigureServices(services =>
                {
                    services.AddControllers(ApiConfiguration.ConfigureControllers)
                        .WithApiControllers()
                        .AddNewtonsoftJson();

                    services.AddBaseInfrastructure(true);
                })
                .Configure(app =>
                {
                    app.UseRouting();
                    app.UseEndpoints(endpoints => endpoints.MapControllers());
                });

            _server = new TestServer(builder);
        }

        public HttpClient CreateClient() => _server.CreateClient();

        public void Dispose()
        {
            _server.Dispose();
        }
    }
}
