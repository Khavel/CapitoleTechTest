using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    /// <summary>
    /// Request to create a new vehicle via HTTP.
    /// </summary>
    public sealed class CreateVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets the brand of the vehicle.
        /// </summary>
        [Required]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the model of the vehicle.
        /// </summary>
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the manufacture year of the vehicle.
        /// </summary>
        [Range(1980, 2100)]
        public int Year { get; set; }
    }
}
