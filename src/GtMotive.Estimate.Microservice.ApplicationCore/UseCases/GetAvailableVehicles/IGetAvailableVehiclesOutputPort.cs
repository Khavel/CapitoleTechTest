namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles
{
    /// <summary>
    /// Defines the output port for the GetAvailableVehicles use case.
    /// </summary>
    public interface IGetAvailableVehiclesOutputPort
    {
        /// <summary>
        /// Handles the standard output when available vehicles are found.
        /// </summary>
        /// <param name="output">The output containing the list of available vehicles.</param>
        void Standard(GetAvailableVehiclesOutput output);

        /// <summary>
        /// Handles the case when no available vehicles are found.
        /// </summary>
        void EmptyResult();

        /// <summary>
        /// Handles unexpected or error scenarios.
        /// </summary>
        /// <param name="message">The error message.</param>
        void ErrorHandle(string message);
    }
}
