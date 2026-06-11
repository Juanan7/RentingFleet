using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle
{
    /// <summary>
    /// Use case that adds a new vehicle to the renting fleet.
    /// </summary>
    public class AddVehicleUseCase(IVehicleRepository vehicleRepository, IAddVehicleOutputPort outputPort) : IUseCase<AddVehicleInput>
    {
        /// <inheritdoc/>
        public async Task Execute(AddVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            try
            {
                var manufactureDate = new ManufactureDate(input.ManufactureDate);
                var vehicle = new Vehicle(VehicleId.New(), input.Brand, input.Model, manufactureDate);

                await vehicleRepository.AddAsync(vehicle);

                outputPort.StandardHandle(new AddVehicleOutput(
                    vehicle.Id.ToGuid(),
                    vehicle.Brand,
                    vehicle.Model,
                    vehicle.ManufactureDate.Value));
            }
            catch (DomainException ex)
            {
                outputPort.NotFoundHandle(ex.Message);
            }
        }
    }
}
