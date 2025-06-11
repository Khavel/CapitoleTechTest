using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Use case for renting a vehicle.
    /// </summary>
    public sealed class RentVehicleUseCase : IUseCase<RentVehicleInput>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRentVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        /// <param name="outputPort">The output port to present results.</param>
        public RentVehicleUseCase(
            IVehicleRepository vehicleRepository,
            IRentVehicleOutputPort outputPort)
        {
            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
        }

        /// <inheritdoc/>
        public async Task Execute(RentVehicleInput input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            try
            {
                var vehicle = await _vehicleRepository.GetByIdAsync(input.VehicleId);

                if (vehicle == null)
                {
                    _outputPort.NotFound($"Vehicle with ID '{input.VehicleId}' was not found.");
                    return;
                }

                if (!vehicle.IsAvailable)
                {
                    _outputPort.VehicleNotAvailable("The vehicle is currently not available.");
                    return;
                }

                var alreadyRenting = await _vehicleRepository.IsVehicleRentedByCustomerAsync(input.CustomerId);
                if (alreadyRenting)
                {
                    _outputPort.CustomerAlreadyRenting("The customer already has a rented vehicle.");
                    return;
                }

                vehicle.RentTo(input.CustomerId);
                await _vehicleRepository.UpdateAsync(vehicle);

                _outputPort.Standard(new RentVehicleOutput(vehicle.Id, vehicle.Brand, vehicle.Model));
            }
            catch (Exception ex)
            {
                _outputPort.VehicleNotAvailable($"Unexpected error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
