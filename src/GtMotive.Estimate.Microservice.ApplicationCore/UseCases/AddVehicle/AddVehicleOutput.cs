using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle
{
    /// <summary>
    /// Output message produced by the <see cref="AddVehicleUseCase"/> on success.
    /// </summary>
    /// <param name="vehicleId">The identifier of the newly created vehicle.</param>
    /// <param name="brand">The brand of the vehicle.</param>
    /// <param name="model">The model of the vehicle.</param>
    /// <param name="manufactureDate">The manufacture date of the vehicle.</param>
    public class AddVehicleOutput(Guid vehicleId, string brand, string model, DateTime manufactureDate) : IUseCaseOutput
    {
        /// <summary>Gets the identifier of the newly created vehicle.</summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>Gets the brand of the vehicle.</summary>
        public string Brand { get; } = brand;

        /// <summary>Gets the model of the vehicle.</summary>
        public string Model { get; } = model;

        /// <summary>Gets the manufacture date of the vehicle.</summary>
        public DateTime ManufactureDate { get; } = manufactureDate;
    }
}
