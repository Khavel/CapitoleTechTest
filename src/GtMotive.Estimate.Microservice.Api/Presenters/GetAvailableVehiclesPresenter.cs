using System;
using System.Linq;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.ViewModels;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    /// <summary>
    /// Prepares HTTP responses for the GetAvailableVehicles use case.
    /// </summary>
    public sealed class GetAvailableVehiclesPresenter : IWebApiPresenter, IGetAvailableVehiclesOutputPort
    {
        /// <inheritdoc />
        public IActionResult ActionResult { get; private set; }

        /// <inheritdoc />
        public void Standard(GetAvailableVehiclesOutput output)
        {
            if (output is null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var result = output.Vehicles
                .Select(v => new AvailableVehicleResponse(v.Id.ToString(), v.Brand, v.Model, v.ManufactureYear.Value))
                .ToList();

            ActionResult = new OkObjectResult(result);
        }

        /// <inheritdoc />
        public void EmptyResult()
        {
            ActionResult = new NoContentResult();
        }

        /// <inheritdoc />
        public void ErrorHandle(string message)
        {
            ActionResult = new ObjectResult(message)
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }
    }
}
