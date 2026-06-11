using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Input message for the <see cref="RentVehicleUseCase"/>.
    /// </summary>
    /// <param name="vehicleId">The identifier of the vehicle to rent.</param>
    /// <param name="customerId">The identifier of the customer renting the vehicle.</param>
    public class RentVehicleInput(Guid vehicleId, CustomerId customerId) : IUseCaseInput
    {
        /// <summary>Gets the identifier of the vehicle to rent.</summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>Gets the identifier of the customer renting the vehicle.</summary>
        public CustomerId CustomerId { get; } = customerId;
    }
}
