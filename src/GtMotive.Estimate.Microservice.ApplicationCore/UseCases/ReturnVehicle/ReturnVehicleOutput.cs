using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Output message produced by the <see cref="ReturnVehicleUseCase"/> on success.
    /// </summary>
    /// <param name="vehicleId">The identifier of the returned vehicle.</param>
    public class ReturnVehicleOutput(Guid vehicleId) : IUseCaseOutput
    {
        /// <summary>Gets the identifier of the returned vehicle.</summary>
        public Guid VehicleId { get; } = vehicleId;
    }
}
