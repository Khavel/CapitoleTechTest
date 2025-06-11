using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    /// <summary>
    /// Request to return a vehicle via HTTP.
    /// </summary>
    public sealed class ReturnVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets the ID of the vehicle to return.
        /// </summary>
        [Required]
        public string VehicleId { get; set; }
    }
}
