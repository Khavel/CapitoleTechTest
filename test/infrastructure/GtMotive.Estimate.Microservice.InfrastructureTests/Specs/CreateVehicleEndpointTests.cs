using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    [Collection(TestCollections.TestServer)]
    public sealed class CreateVehicleEndpointTests : InfrastructureTestBase
    {
        public CreateVehicleEndpointTests(GenericInfrastructureTestServerFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task PostVehicleShouldReturnCreatedWhenVehicleIsValid()
        {
            // Arrange
            var client = Fixture.Server.CreateClient();
            var request = new CreateVehicleRequest
            {
                Brand = "Ford",
                Model = "Focus",
                Year = System.DateTime.UtcNow.Year - 1
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/vehicles", request);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task PostVehicleShouldReturnBadRequestWhenYearIsTooOld()
        {
            // Arrange
            var client = Fixture.Server.CreateClient();
            var request = new CreateVehicleRequest
            {
                Brand = "Opel",
                Model = "Corsa",
                Year = System.DateTime.UtcNow.Year - 10
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/vehicles", request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostVehicleShouldReturnBadRequestWhenDataIsInvalid()
        {
            // Arrange
            var client = Fixture.Server.CreateClient();
            var request = new CreateVehicleRequest();

            // Act
            var response = await client.PostAsJsonAsync("/api/vehicles", request);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
