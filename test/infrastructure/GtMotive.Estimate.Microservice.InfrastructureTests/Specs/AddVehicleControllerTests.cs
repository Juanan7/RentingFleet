using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    [Collection(TestCollections.TestServer)]
    public sealed class AddVehicleControllerTests(GenericInfrastructureTestServerFixture fixture)
    {
        [Fact]
        public async Task PostVehicleWithMissingBrandReturnsBadRequest()
        {
            // Arrange
            var client = fixture.CreateClient();

            var body = new
            {
                model = "Corsa",
                manufactureDate = "2024-01-01"
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/vehicles", body);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task PostVehicleWithMissingModelReturnsBadRequest()
        {
            // Arrange
            var client = fixture.CreateClient();

            var body = new
            {
                brand = "Opel",
                manufactureDate = "2024-01-01"
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/vehicles", body);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
