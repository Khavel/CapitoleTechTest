namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Represents the input parameters required to create a new vehicle.
    /// </summary>
    public class CreateVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Gets the brand of the vehicle.
        /// </summary>
        public string Brand { get; init; }

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        public string Model { get; init; }

        /// <summary>
        /// Gets the manufacture year of the vehicle.
        /// </summary>
        public int Year { get; init; }
    }
}
