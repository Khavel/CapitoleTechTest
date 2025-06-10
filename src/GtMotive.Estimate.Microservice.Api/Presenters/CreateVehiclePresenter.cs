using System;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.ViewModels;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    /// <summary>
    /// Converts CreateVehicle use case output to HTTP responses.
    /// </summary>
    public sealed class CreateVehiclePresenter : ICreateVehicleOutputPort, IWebApiPresenter
    {
        /// <inheritdoc/>
        public IActionResult ActionResult { get; private set; }

        /// <inheritdoc/>
        public void Standard(CreateVehicleOutput output)
        {
            if (output is null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var response = new CreateVehicleResponse(output.Id);
            ActionResult = new CreatedResult("/api/vehicles", response);
        }

        /// <inheritdoc/>
        public void VehicleRejected(string reason)
        {
            ActionResult = new BadRequestObjectResult(new { Error = reason });
        }
    }
}
