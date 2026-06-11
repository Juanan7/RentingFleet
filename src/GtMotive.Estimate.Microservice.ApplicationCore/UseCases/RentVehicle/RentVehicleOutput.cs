using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output message produced by the <see cref="RentVehicleUseCase"/> on success.
    /// </summary>
    /// <param name="vehicleId">The identifier of the rented vehicle.</param>
    /// <param name="customerId">The identifier of the customer who rented the vehicle.</param>
    public class RentVehicleOutput(Guid vehicleId, CustomerId customerId) : IUseCaseOutput
    {
        /// <summary>Gets the identifier of the rented vehicle.</summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>Gets the identifier of the customer who rented the vehicle.</summary>
        public CustomerId CustomerId { get; } = customerId;
    }
}
