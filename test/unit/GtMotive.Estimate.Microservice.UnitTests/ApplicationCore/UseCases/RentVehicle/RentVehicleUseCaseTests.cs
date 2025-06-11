using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore.UseCases.RentVehicle
{
    public class RentVehicleUseCaseTests
    {
        [Fact]
        public async Task ShouldReturnNotFoundWhenVehicleDoesNotExist()
        {
            // Arrange
            var vehicleRepoMock = new Mock<IVehicleRepository>();
            var outputPortMock = new Mock<IRentVehicleOutputPort>();

            var useCase = new RentVehicleUseCase(vehicleRepoMock.Object, outputPortMock.Object);

            var input = new RentVehicleInput(new VehicleId(Guid.NewGuid()), new CustomerId(Guid.NewGuid()));

            vehicleRepoMock
                .Setup(r => r.GetByIdAsync(input.VehicleId))
                .ReturnsAsync((Vehicle)null); // Simula vehículo no encontrado

            // Act
            await useCase.Execute(input);

            // Assert
            outputPortMock.Verify(o => o.NotFound(It.Is<string>(msg => msg.Contains("not found"))), Times.Once);
        }
    }
}
