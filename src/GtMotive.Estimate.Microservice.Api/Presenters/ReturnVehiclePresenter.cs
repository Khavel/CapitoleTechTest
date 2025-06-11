using System;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    /// <summary>
    /// Presents the result of the ReturnVehicle use case as an HTTP response.
    /// </summary>
    public sealed class ReturnVehiclePresenter : IWebApiPresenter, IReturnVehicleOutputPort
    {
        /// <inheritdoc/>
        public IActionResult ActionResult { get; private set; }

        /// <inheritdoc/>
        public void Standard(ReturnVehicleOutput output)
        {
            if (output is null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            ActionResult = new OkObjectResult(new
            {
                output.VehicleId
            });
        }

        /// <inheritdoc/>
        public void NotFound(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        /// <inheritdoc/>
        public void InvalidState(string message)
        {
            ActionResult = new ConflictObjectResult(message);
        }
    }
}
