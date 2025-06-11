using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.GetAvailableVehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle;
using GtMotive.Estimate.Microservice.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// REST controller for managing vehicle operations such as creation, availability, rental, and return.
    /// </summary>
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehiclesController"/> class.
        /// </summary>
        /// <param name="mediator">MediatR dispatcher.</param>
        public VehiclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new vehicle in the fleet.
        /// </summary>
        /// <param name="request">The request containing brand, model, and year.</param>
        /// <returns>An HTTP response with the created vehicle ID.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleRequest request)
        {
            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Gets the list of vehicles currently available for rent.
        /// </summary>
        /// <returns>A list of available vehicles.</returns>
        [HttpGet("available")]
        [ProducesResponseType(typeof(List<AvailableVehicleResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAvailableVehicles()
        {
            var presenter = await _mediator.Send(new GetAvailableVehiclesRequest());
            return presenter.ActionResult;
        }

        /// <summary>
        /// Rents a vehicle to a customer.
        /// </summary>
        /// <param name="request">The request containing the vehicle and customer identifiers.</param>
        /// <returns>An HTTP response indicating success or failure.</returns>
        [HttpPost("rent")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> RentVehicle([FromBody] RentVehicleRequest request)
        {
            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Returns a rented vehicle to the fleet.
        /// </summary>
        /// <param name="request">The request containing the vehicle identifier to return.</param>
        /// <returns>An HTTP response indicating the result of the operation.</returns>
        [HttpPost("return")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> ReturnVehicle([FromBody] ReturnVehicleRequest request)
        {
            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }
    }
}
