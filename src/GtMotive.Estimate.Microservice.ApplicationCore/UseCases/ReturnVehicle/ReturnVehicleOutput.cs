using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Output data returned after a successful vehicle return.
    /// </summary>
    public sealed class ReturnVehicleOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleOutput"/> class.
        /// </summary>
        /// <param name="vehicleId">The ID of the returned vehicle.</param>
        public ReturnVehicleOutput(VehicleId vehicleId)
        {
            VehicleId = vehicleId;
        }

        /// <summary>
        /// Gets the ID of the returned vehicle.
        /// </summary>
        public VehicleId VehicleId { get; }
    }
}
