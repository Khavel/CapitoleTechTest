using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output data returned after a successful vehicle rental.
    /// </summary>
    public sealed class RentVehicleOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleOutput"/> class.
        /// </summary>
        /// <param name="vehicleId">The ID of the rented vehicle.</param>
        /// <param name="brand">The vehicle brand.</param>
        /// <param name="model">The vehicle model.</param>
        public RentVehicleOutput(VehicleId vehicleId, string brand, string model)
        {
            VehicleId = vehicleId;
            Brand = brand;
            Model = model;
        }

        /// <summary>
        /// Gets the ID of the rented vehicle.
        /// </summary>
        public VehicleId VehicleId { get; }

        /// <summary>
        /// Gets the brand of the vehicle.
        /// </summary>
        public string Brand { get; }

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        public CustomerId CustomerId { get; }
    }
}
