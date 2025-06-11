using System;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.ViewModels;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    /// <summary>
    /// Prepares HTTP responses for the RentVehicle use case.
    /// </summary>
    public sealed class RentVehiclePresenter : IWebApiPresenter, IRentVehicleOutputPort
    {
        /// <inheritdoc />
        public IActionResult ActionResult { get; private set; }

        /// <inheritdoc />
        public void Standard(RentVehicleOutput output)
        {
            if (output is null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var response = new RentVehicleResponse(
                output.VehicleId.ToString(),
                output.CustomerId.ToString());

            ActionResult = new OkObjectResult(response);
        }

        /// <inheritdoc />
        public void VehicleNotAvailable(string message)
        {
            ActionResult = new BadRequestObjectResult(new { Message = message });
        }

        /// <inheritdoc />
        public void CustomerAlreadyRenting(string message)
        {
            ActionResult = new ConflictObjectResult(new { Message = message });
        }

        /// <inheritdoc />
        public void NotFound(string message)
        {
            ActionResult = new NotFoundObjectResult(new { Message = message });
        }
    }
}
