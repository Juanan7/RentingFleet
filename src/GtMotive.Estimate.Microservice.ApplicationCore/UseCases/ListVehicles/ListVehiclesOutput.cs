using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListVehicles
{
    /// <summary>
    /// Output message produced by the <see cref="ListVehiclesUseCase"/> on success.
    /// </summary>
    /// <param name="vehicles">The list of available vehicles.</param>
    public class ListVehiclesOutput(IReadOnlyList<VehicleDto> vehicles) : IUseCaseOutput
    {
        /// <summary>Gets the list of available vehicles.</summary>
        public IReadOnlyList<VehicleDto> Vehicles { get; } = vehicles;
    }
}
