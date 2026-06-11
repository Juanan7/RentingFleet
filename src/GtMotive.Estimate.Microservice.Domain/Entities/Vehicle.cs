using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a vehicle in the renting fleet.
    /// </summary>
    /// <param name="id">The unique identifier of the vehicle.</param>
    /// <param name="brand">The brand of the vehicle.</param>
    /// <param name="model">The model of the vehicle.</param>
    /// <param name="manufactureDate">The manufacture date of the vehicle.</param>
    public class Vehicle(VehicleId id, string brand, string model, ManufactureDate manufactureDate)
    {
        /// <summary>Gets the unique identifier of the vehicle.</summary>
        public VehicleId Id { get; } = id;

        /// <summary>Gets the brand of the vehicle.</summary>
        public string Brand { get; } = brand;

        /// <summary>Gets the model of the vehicle.</summary>
        public string Model { get; } = model;

        /// <summary>Gets the manufacture date of the vehicle.</summary>
        public ManufactureDate ManufactureDate { get; } = manufactureDate;

        /// <summary>Gets a value indicating whether the vehicle is currently rented.</summary>
        public bool IsRented { get; private set; }

        /// <summary>Gets the identifier of the customer who has rented this vehicle.</summary>
        public CustomerId RentedByCustomerId { get; private set; }

        /// <summary>
        /// Marks the vehicle as rented by the specified customer.
        /// </summary>
        /// <param name="customerId">The identifier of the customer renting the vehicle.</param>
        /// <exception cref="DomainException">Thrown when the vehicle is already rented.</exception>
        public void Rent(CustomerId customerId)
        {
            if (IsRented)
            {
                throw new DomainException($"Vehicle {Id} is already rented.");
            }

            IsRented = true;
            RentedByCustomerId = customerId;
        }

        /// <summary>
        /// Marks the vehicle as returned and available again.
        /// </summary>
        /// <exception cref="DomainException">Thrown when the vehicle is not currently rented.</exception>
        public void Return()
        {
            if (!IsRented)
            {
                throw new DomainException($"Vehicle {Id} is not currently rented.");
            }

            IsRented = false;
            RentedByCustomerId = default;
        }
    }
}
