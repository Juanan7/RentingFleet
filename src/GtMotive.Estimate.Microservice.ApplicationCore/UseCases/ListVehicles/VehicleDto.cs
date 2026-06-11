using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListVehicles
{
    /// <summary>
    /// Data transfer object representing a vehicle in the list.
    /// </summary>
    /// <param name="vehicleId">The vehicle identifier.</param>
    /// <param name="brand">The brand of the vehicle.</param>
    /// <param name="model">The model of the vehicle.</param>
    /// <param name="manufactureDate">The manufacture date of the vehicle.</param>
    public class VehicleDto(Guid vehicleId, string brand, string model, DateTime manufactureDate)
    {
        /// <summary>Gets the vehicle identifier.</summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>Gets the brand of the vehicle.</summary>
        public string Brand { get; } = brand;

        /// <summary>Gets the model of the vehicle.</summary>
        public string Model { get; } = model;

        /// <summary>Gets the manufacture date of the vehicle.</summary>
        public DateTime ManufactureDate { get; } = manufactureDate;
    }
}
