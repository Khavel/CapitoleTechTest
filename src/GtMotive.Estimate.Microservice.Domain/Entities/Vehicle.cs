using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Represents a vehicle within the renting system.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="id">The unique vehicle identifier.</param>
        /// <param name="brand">The brand name of the vehicle.</param>
        /// <param name="model">The model name of the vehicle.</param>
        /// <param name="year">The manufacture year.</param>
        public Vehicle(VehicleId id, string brand, string model, Year year)
        {
            Id = id;
            Brand = !string.IsNullOrWhiteSpace(brand) ? brand : throw new ArgumentException("Brand is required.");
            Model = !string.IsNullOrWhiteSpace(model) ? model : throw new ArgumentException("Model is required.");
            ManufactureYear = year;
        }

        /// <summary>
        /// Gets the unique identifier for the vehicle.
        /// </summary>
        public VehicleId Id { get; private set; }

        /// <summary>
        /// Gets the brand of the vehicle.
        /// </summary>
        public string Brand { get; private set; }

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        public string Model { get; private set; }

        /// <summary>
        /// Gets the manufacture year of the vehicle.
        /// </summary>
        public Year ManufactureYear { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the vehicle is currently available.
        /// </summary>
        public bool IsAvailable => RentedBy == null;

        /// <summary>
        /// Gets the customer who has rented the vehicle, if any.
        /// </summary>
        public CustomerId? RentedBy { get; private set; }

        /// <summary>
        /// Determines whether the vehicle is eligible to be part of the fleet.
        /// </summary>
        /// <returns><c>true</c> if the vehicle's manufacture year is within 5 years; otherwise, <c>false</c>.</returns>
        public bool IsEligibleForFleet()
        {
            return ManufactureYear.Value >= DateTime.UtcNow.Year - 5;
        }

        /// <summary>
        /// Marks the vehicle as rented by the specified customer.
        /// </summary>
        /// <param name="customerId">The customer renting the vehicle.</param>
        /// <exception cref="InvalidOperationException">Thrown when the vehicle is already rented.</exception>
        public void RentTo(CustomerId customerId)
        {
            if (!IsAvailable)
            {
                throw new InvalidOperationException("The vehicle is not available for rent.");
            }

            RentedBy = customerId;
        }

        /// <summary>
        /// Marks the vehicle as returned.
        /// </summary>
        public void Return()
        {
            if (IsAvailable)
            {
                throw new InvalidOperationException("Vehicle is not currently rented.");
            }

            RentedBy = null;
        }
    }
}
