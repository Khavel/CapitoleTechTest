using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Infrastructure.Persistence
{
    /// <summary>
    /// In-memory implementation of the IVehicleRepository for testing and development.
    /// </summary>
    public sealed class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles = new();

        /// <inheritdoc/>
        public Task AddAsync(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task<Vehicle> GetByIdAsync(VehicleId id)
        {
            return Task.FromResult(_vehicles.FirstOrDefault(v => v.Id.Equals(id)));
        }

        /// <inheritdoc/>
        public Task<List<Vehicle>> GetAvailableAsync()
        {
            return Task.FromResult(_vehicles.Where(v => v.IsAvailable).ToList());
        }

        /// <inheritdoc/>
        public Task<bool> IsVehicleRentedByCustomerAsync(CustomerId customerId)
        {
            var exists = _vehicles.Any(v => v.RentedBy?.Value == customerId.Value);
            return Task.FromResult(exists);
        }

        /// <inheritdoc/>
        public Task UpdateAsync(Vehicle vehicle)
        {
            // No-op for in-memory repository
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Vehicle>>(_vehicles);
        }

        public void SeedTestData()
        {
            var now = DateTime.UtcNow;

            var v1 = new Vehicle(
                new VehicleId(Guid.NewGuid()),
                "Tesla",
                "Model S",
                new Year(now.Year - 2));

            var v2 = new Vehicle(
                new VehicleId(Guid.NewGuid()),
                "Toyota",
                "Corolla",
                new Year(now.Year - 1));

            _vehicles.Add(v1);
            _vehicles.Add(v2);
        }
    }
}
