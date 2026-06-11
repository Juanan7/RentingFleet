using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Use case that returns a rented vehicle back to the fleet.
    /// </summary>
    public class ReturnVehicleUseCase(IVehicleRepository vehicleRepository, IReturnVehicleOutputPort outputPort) : IUseCase<ReturnVehicleInput>
    {
        /// <inheritdoc/>
        public async Task Execute(ReturnVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = await vehicleRepository.GetByIdAsync(new VehicleId(input.VehicleId));
            if (vehicle is null)
            {
                outputPort.NotFoundHandle($"Vehicle {input.VehicleId} not found.");
                return;
            }

            try
            {
                vehicle.Return();
                await vehicleRepository.UpdateAsync(vehicle);
                outputPort.StandardHandle(new ReturnVehicleOutput(vehicle.Id.ToGuid()));
            }
            catch (DomainException ex)
            {
                outputPort.NotFoundHandle(ex.Message);
            }
        }
    }
}
