using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Input data for renting a vehicle.
    /// </summary>
    public sealed class RentVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleInput"/> class.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to rent.</param>
        /// <param name="customerId">The ID of the customer renting the vehicle.</param>
        public RentVehicleInput(VehicleId vehicleId, CustomerId customerId)
        {
            VehicleId = vehicleId;
            CustomerId = customerId;
        }

        /// <summary>
        /// Gets the vehicle ID.
        /// </summary>
        public VehicleId VehicleId { get; }

        /// <summary>
        /// Gets the customer ID.
        /// </summary>
        public CustomerId CustomerId { get; }
    }
}
