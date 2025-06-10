using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Contract for accessing and managing vehicles in the system.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Adds a vehicle asynchronously.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddAsync(Vehicle vehicle);

        /// <summary>
        /// Gets a vehicle by its ID.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <returns>The vehicle, if found.</returns>
        Task<Vehicle> GetByIdAsync(VehicleId id);

        /// <summary>
        /// Gets all vehicles that are currently available.
        /// </summary>
        /// <returns>A list of available vehicles.</returns>
        Task<List<Vehicle>> GetAvailableAsync();

        /// <summary>
        /// Checks if the customer has a vehicle rented.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns><c>true</c> if the customer has a rented vehicle; otherwise, <c>false</c>.</returns>
        Task<bool> IsVehicleRentedByCustomerAsync(CustomerId customerId);

        /// <summary>
        /// Updates a vehicle asynchronously.
        /// </summary>
        /// <param name="vehicle">The vehicle to update.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task UpdateAsync(Vehicle vehicle);
    }
}
