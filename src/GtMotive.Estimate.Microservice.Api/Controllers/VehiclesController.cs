using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// REST controller for managing vehicles.
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
    }
}
