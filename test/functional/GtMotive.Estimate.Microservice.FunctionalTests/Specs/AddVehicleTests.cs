using System;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    [Collection(TestCollections.Functional)]
    public sealed class AddVehicleTests(CompositionRootTestFixture fixture)
    {
        [Fact]
        public async Task AddVehicleWithValidInputReturns201WithVehicleData()
        {
            // Arrange
            using var scope = fixture.ServiceProvider.CreateScope();
            var useCase = scope.ServiceProvider.GetRequiredService<IUseCase<AddVehicleInput>>();
            var presenter = scope.ServiceProvider.GetRequiredService<AddVehiclePresenter>();

            var input = new AddVehicleInput(
                brand: "Seat",
                model: "Ibiza",
                manufactureDate: DateTime.UtcNow.AddYears(-2));

            // Act
            await useCase.Execute(input);

            // Assert
            var result = presenter.ActionResult as ObjectResult;
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task AddVehicleWithInvalidDateReturns400()
        {
            // Arrange
            using var scope = fixture.ServiceProvider.CreateScope();
            var useCase = scope.ServiceProvider.GetRequiredService<IUseCase<AddVehicleInput>>();
            var presenter = scope.ServiceProvider.GetRequiredService<AddVehiclePresenter>();

            var input = new AddVehicleInput(
                brand: "Seat",
                model: "Ibiza",
                manufactureDate: DateTime.UtcNow.AddYears(-6));

            // Act
            await useCase.Execute(input);

            // Assert
            var result = presenter.ActionResult as BadRequestObjectResult;
            result.Should().NotBeNull();
        }
    }
}
