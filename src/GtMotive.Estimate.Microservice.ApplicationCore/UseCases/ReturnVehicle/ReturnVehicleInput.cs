using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Input message for the <see cref="ReturnVehicleUseCase"/>.
    /// </summary>
    /// <param name="vehicleId">The identifier of the vehicle to return.</param>
    public class ReturnVehicleInput(Guid vehicleId) : IUseCaseInput
    {
        /// <summary>Gets the identifier of the vehicle to return.</summary>
        public Guid VehicleId { get; } = vehicleId;
    }
}
