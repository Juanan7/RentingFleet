using System;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    /// <summary>
    /// Unit tests for <see cref="AddVehicleUseCase"/>.
    /// </summary>
    public class AddVehicleUseCaseTests
    {
        private readonly Mock<IVehicleRepository> _repositoryMock;
        private readonly Mock<IAddVehicleOutputPort> _outputPortMock;
        private readonly AddVehicleUseCase _sut;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddVehicleUseCaseTests"/> class.
        /// </summary>
        public AddVehicleUseCaseTests()
        {
            _repositoryMock = new Mock<IVehicleRepository>();
            _outputPortMock = new Mock<IAddVehicleOutputPort>();
            _sut = new AddVehicleUseCase(_repositoryMock.Object, _outputPortMock.Object);
        }

        /// <summary>
        /// Verifies that a valid input results in the vehicle being persisted and the standard output port being called.
        /// </summary>
        /// <returns>A task representing the asynchronous test.</returns>
        [Fact]
        public async Task ExecuteWithValidInputAddsVehicleAndCallsStandardHandle()
        {
            // Arrange
            var input = new AddVehicleInput(
                brand: "Opel",
                model: "Corsa",
                manufactureDate: DateTime.UtcNow.AddYears(-1));

            AddVehicleOutput capturedOutput = null;
            _outputPortMock
                .Setup(p => p.StandardHandle(It.IsAny<AddVehicleOutput>()))
                .Callback<AddVehicleOutput>(output => capturedOutput = output);

            // Act
            await _sut.Execute(input);

            // Assert
            _repositoryMock.Verify(
                r => r.AddAsync(It.Is<Domain.Entities.Vehicle>(v =>
                    v.Brand == "Opel" &&
                    v.Model == "Corsa")),
                Times.Once);

            _outputPortMock.Verify(p => p.StandardHandle(It.IsAny<AddVehicleOutput>()), Times.Once);
            _outputPortMock.Verify(p => p.NotFoundHandle(It.IsAny<string>()), Times.Never);

            capturedOutput.Should().NotBeNull();
            capturedOutput.Brand.Should().Be("Opel");
            capturedOutput.Model.Should().Be("Corsa");
            capturedOutput.VehicleId.Should().NotBe(Guid.Empty);
        }

        /// <summary>
        /// Verifies that a manufacture date older than five years triggers the not-found output port and nothing is persisted.
        /// </summary>
        /// <returns>A task representing the asynchronous test.</returns>
        [Fact]
        public async Task ExecuteWithManufactureDateOlderThanFiveYearsCallsNotFoundHandle()
        {
            // Arrange
            var input = new AddVehicleInput(
                brand: "Ford",
                model: "Focus",
                manufactureDate: DateTime.UtcNow.AddYears(-6));

            // Act
            await _sut.Execute(input);

            // Assert
            _outputPortMock.Verify(p => p.NotFoundHandle(It.IsAny<string>()), Times.Once);
            _outputPortMock.Verify(p => p.StandardHandle(It.IsAny<AddVehicleOutput>()), Times.Never);
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Domain.Entities.Vehicle>()), Times.Never);
        }
    }
}
