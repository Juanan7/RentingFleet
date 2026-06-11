using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Port that defines the persistence operations required by the domain for vehicles.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>Adds a new vehicle to the repository.</summary>
        /// <param name="vehicle">The vehicle to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAsync(Vehicle vehicle);

        /// <summary>Returns all vehicles that are currently available for renting.</summary>
        /// <returns>A read-only list of available vehicles.</returns>
        Task<IReadOnlyList<Vehicle>> GetAvailableAsync();

        /// <summary>Finds a vehicle by its identifier.</summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <returns>The vehicle if found, otherwise <c>null</c>.</returns>
        Task<Vehicle> GetByIdAsync(VehicleId id);

        /// <summary>Indicates whether a customer already has an active rental.</summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns><c>true</c> if the customer has an active rental; otherwise <c>false</c>.</returns>
        Task<bool> CustomerHasActiveRentalAsync(CustomerId customerId);

        /// <summary>Persists changes to an existing vehicle.</summary>
        /// <param name="vehicle">The vehicle to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(Vehicle vehicle);
    }
}
