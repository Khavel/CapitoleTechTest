namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Contract for presenting the result of the ReturnVehicle use case.
    /// </summary>
    public interface IReturnVehicleOutputPort
    {
        /// <summary>
        /// Called when the vehicle has been successfully returned.
        /// </summary>
        /// <param name="output">The output data.</param>
        void Standard(ReturnVehicleOutput output);

        /// <summary>
        /// Called when the requested vehicle does not exist.
        /// </summary>
        /// <param name="message">The error message.</param>
        void NotFound(string message);

        /// <summary>
        /// Called when the vehicle is not currently rented.
        /// </summary>
        /// <param name="message">The error message.</param>
        void InvalidState(string message);
    }
}
