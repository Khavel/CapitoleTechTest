using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Use case for returning a rented vehicle.
    /// </summary>
    public sealed class ReturnVehicleUseCase : IUseCase<ReturnVehicleInput>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReturnVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="outputPort">The output port to present results.</param>
        public ReturnVehicleUseCase(
            IVehicleRepository vehicleRepository,
            IUnitOfWork unitOfWork,
            IReturnVehicleOutputPort outputPort)
        {
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
        }

        /// <inheritdoc/>
        public async Task Execute(ReturnVehicleInput input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var vehicle = await _vehicleRepository.GetByIdAsync(input.VehicleId);

            if (vehicle == null)
            {
                _outputPort.NotFound($"Vehicle with ID '{input.VehicleId}' was not found.");
                return;
            }

            try
            {
                vehicle.Return();
                await _vehicleRepository.UpdateAsync(vehicle);
                await _unitOfWork.Save();

                _outputPort.Standard(new ReturnVehicleOutput(vehicle.Id));
            }
            catch (InvalidOperationException ex)
            {
                _outputPort.InvalidState(ex.Message);
            }
        }
    }
}
