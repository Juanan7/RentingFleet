using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Use case that rents a vehicle to a customer.
    /// </summary>
    public class RentVehicleUseCase(IVehicleRepository vehicleRepository, IRentVehicleOutputPort outputPort) : IUseCase<RentVehicleInput>
    {
        /// <inheritdoc/>
        public async Task Execute(RentVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var hasActiveRental = await vehicleRepository.CustomerHasActiveRentalAsync(input.CustomerId);
            if (hasActiveRental)
            {
                outputPort.NotFoundHandle("Customer already has an active rental.");
                return;
            }

            var vehicle = await vehicleRepository.GetByIdAsync(new VehicleId(input.VehicleId));
            if (vehicle is null)
            {
                outputPort.NotFoundHandle($"Vehicle {input.VehicleId} not found.");
                return;
            }

            try
            {
                vehicle.Rent(input.CustomerId);
                await vehicleRepository.UpdateAsync(vehicle);
                outputPort.StandardHandle(new RentVehicleOutput(vehicle.Id.ToGuid(), input.CustomerId));
            }
            catch (DomainException ex)
            {
                outputPort.NotFoundHandle(ex.Message);
            }
        }
    }
}
