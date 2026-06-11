using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// In-memory implementation of <see cref="IVehicleRepository"/>.
    /// Stores vehicles in a thread-safe dictionary for the lifetime of the application.
    /// </summary>
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ConcurrentDictionary<string, Vehicle> _store = new();

        /// <inheritdoc/>
        public Task AddAsync(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);
            Upsert(vehicle);
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task<IReadOnlyList<Vehicle>> GetAvailableAsync()
        {
            return Task.FromResult<IReadOnlyList<Vehicle>>(GetAvailableVehicles());
        }

        /// <inheritdoc/>
        public Task<Vehicle> GetByIdAsync(VehicleId id)
        {
            _store.TryGetValue(id.ToString(), out var vehicle);
            return Task.FromResult(vehicle);
        }

        /// <inheritdoc/>
        public Task<bool> CustomerHasActiveRentalAsync(CustomerId customerId)
        {
            var hasRental = _store.Values
                .Any(v => v.IsRented && v.RentedByCustomerId == customerId);

            return Task.FromResult(hasRental);
        }

        /// <inheritdoc/>
        public Task UpdateAsync(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            if (!_store.ContainsKey(vehicle.Id.ToString()))
            {
                throw new Domain.DomainException($"Vehicle {vehicle.Id} does not exist and cannot be updated.");
            }

            Upsert(vehicle);
            return Task.CompletedTask;
        }

        private ReadOnlyCollection<Vehicle> GetAvailableVehicles()
        {
            return _store.Values
                .Where(v => !v.IsRented)
                .ToList()
                .AsReadOnly();
        }

        private void Upsert(Vehicle vehicle)
        {
            _store[vehicle.Id.ToString()] = vehicle;
        }
    }
}
