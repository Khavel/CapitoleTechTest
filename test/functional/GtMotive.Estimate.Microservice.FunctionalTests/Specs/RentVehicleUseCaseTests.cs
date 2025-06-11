using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    [Collection(TestCollections.Functional)]
    public class RentVehicleUseCaseTests : FunctionalTestBase
    {
        public RentVehicleUseCaseTests(CompositionRootTestFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task ShouldRentAnAvailableVehicleAndReturn200OK()
        {
            var vehicleId = Guid.NewGuid();
            var customerId = Guid.NewGuid();

            await Fixture.UsingRepository<IVehicleRepository>(async repo =>
            {
                var vehicle = new Vehicle(
                    new VehicleId(vehicleId),
                    "Ford",
                    "Focus",
                    new Year(2022));

                await repo.AddAsync(vehicle);
            });

            var request = new RentVehicleRequest
            {
                VehicleId = vehicleId.ToString(),
                CustomerId = customerId.ToString()
            };

            await Fixture.UsingHandlerForRequestResponse<RentVehicleRequest, IWebApiPresenter>(
                async handler =>
                {
                    var presenter = await handler.Handle(request, CancellationToken.None);
                    var result = Assert.IsType<OkObjectResult>(presenter.ActionResult);
                    Assert.NotNull(result.Value);
                });
        }
    }
}
