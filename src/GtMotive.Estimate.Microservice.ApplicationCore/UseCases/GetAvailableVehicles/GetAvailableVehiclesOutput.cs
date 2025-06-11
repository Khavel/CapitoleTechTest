using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles
{
    /// <summary>
    /// Output data containing the list of available vehicles.
    /// </summary>
    public class GetAvailableVehiclesOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAvailableVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">The available vehicles.</param>
        public GetAvailableVehiclesOutput(IReadOnlyCollection<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        /// <summary>
        /// Gets the list of available vehicles.
        /// </summary>
        public IReadOnlyCollection<Vehicle> Vehicles { get; }
    }
}
