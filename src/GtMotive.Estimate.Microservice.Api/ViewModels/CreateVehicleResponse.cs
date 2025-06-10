using System.ComponentModel.DataAnnotations;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.Api.ViewModels
{
    /// <summary>
    /// ViewModel returned after successfully creating a vehicle.
    /// </summary>
    public sealed class CreateVehicleResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleResponse"/> class.
        /// </summary>
        /// <param name="id">The vehicle ID.</param>
        public CreateVehicleResponse(VehicleId id)
        {
            VehicleId = id.ToString();
        }

        /// <summary>
        /// Gets the created vehicle identifier.
        /// </summary>
        [Required]
        public string VehicleId { get; }
    }
}
