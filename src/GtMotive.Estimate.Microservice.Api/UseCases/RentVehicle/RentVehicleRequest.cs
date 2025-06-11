using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    /// <summary>
    /// Request to rent a vehicle via HTTP.
    /// </summary>
    public sealed class RentVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets the vehicle ID to rent.
        /// </summary>
        [Required]
        public string VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the customer ID who is renting the vehicle.
        /// </summary>
        [Required]
        public string CustomerId { get; set; }
    }
}
