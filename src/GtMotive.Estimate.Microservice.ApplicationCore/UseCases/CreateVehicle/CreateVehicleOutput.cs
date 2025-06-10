using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Output model returned after creating a vehicle.
    /// </summary>
    public class CreateVehicleOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleOutput"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the created vehicle.</param>
        public CreateVehicleOutput(VehicleId id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the unique identifier of the created vehicle.
        /// </summary>
        public VehicleId Id { get; }
    }
}
