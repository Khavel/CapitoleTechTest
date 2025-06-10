namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Defines the output port for the CreateVehicle use case.
    /// </summary>
    public interface ICreateVehicleOutputPort
    {
        /// <summary>
        /// Handles the standard success case.
        /// </summary>
        /// <param name="output">The output containing the vehicle ID.</param>
        void Standard(CreateVehicleOutput output);

        /// <summary>
        /// Handles the case where the vehicle creation is rejected.
        /// </summary>
        /// <param name="reason">The reason why the vehicle was rejected.</param>
        void VehicleRejected(string reason);
    }
}
