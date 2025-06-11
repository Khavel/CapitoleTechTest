namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Contract for presenting the result of the RentVehicle use case.
    /// </summary>
    public interface IRentVehicleOutputPort
    {
        /// <summary>
        /// Called when the vehicle has been rented successfully.
        /// </summary>
        /// <param name="output">The output data.</param>
        void Standard(RentVehicleOutput output);

        /// <summary>
        /// Called when the requested vehicle is not available.
        /// </summary>
        /// <param name="message">The reason why it failed.</param>
        void VehicleNotAvailable(string message);

        /// <summary>
        /// Called when the customer is already renting another vehicle.
        /// </summary>
        /// <param name="message">The reason why it failed.</param>
        void CustomerAlreadyRenting(string message);

        /// <summary>
        /// Called when the vehicle is not found.
        /// </summary>
        /// <param name="message">The error message.</param>
        void NotFound(string message);
    }
}
