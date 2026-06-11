using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicle
{
    /// <summary>
    /// Input message for the <see cref="AddVehicleUseCase"/>.
    /// </summary>
    /// <param name="brand">The brand of the vehicle.</param>
    /// <param name="model">The model of the vehicle.</param>
    /// <param name="manufactureDate">The manufacture date of the vehicle.</param>
    public class AddVehicleInput(string brand, string model, DateTime manufactureDate) : IUseCaseInput
    {
        /// <summary>Gets the brand of the vehicle.</summary>
        public string Brand { get; } = brand;

        /// <summary>Gets the model of the vehicle.</summary>
        public string Model { get; } = model;

        /// <summary>Gets the manufacture date of the vehicle.</summary>
        public DateTime ManufactureDate { get; } = manufactureDate;
    }
}
