using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Input data for returning a rented vehicle.
    /// </summary>
    public sealed class ReturnVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleInput"/> class.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to return.</param>
        public ReturnVehicleInput(VehicleId vehicleId)
        {
            VehicleId = vehicleId;
        }

        /// <summary>
        /// Gets the vehicle ID.
        /// </summary>
        public VehicleId VehicleId { get; }
    }
}
