namespace GtMotive.Estimate.Microservice.Api.ViewModels
{
    /// <summary>
    /// Represents the response returned after a vehicle has been successfully rented.
    /// </summary>
    public sealed class RentVehicleResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleResponse"/> class.
        /// </summary>
        /// <param name="vehicleId">The identifier of the rented vehicle.</param>
        /// <param name="customerId">The identifier of the customer who rented the vehicle.</param>
        public RentVehicleResponse(string vehicleId, string customerId)
        {
            VehicleId = vehicleId;
            CustomerId = customerId;
        }

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public string VehicleId { get; }

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        public string CustomerId { get; }
    }
}
