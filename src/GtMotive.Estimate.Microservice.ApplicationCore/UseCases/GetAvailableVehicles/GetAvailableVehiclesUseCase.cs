using System;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles
{
    /// <summary>
    /// Handles the use case logic for retrieving available vehicles.
    /// </summary>
    public sealed class GetAvailableVehiclesUseCase : IUseCase<GetAvailableVehiclesInput>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IGetAvailableVehiclesOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAvailableVehiclesUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        /// <param name="outputPort">The output port to communicate results.</param>
        public GetAvailableVehiclesUseCase(
            IVehicleRepository vehicleRepository,
            IGetAvailableVehiclesOutputPort outputPort)
        {
            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
        }

        /// <inheritdoc />
        public async Task Execute(GetAvailableVehiclesInput input)
        {
            try
            {
                var vehicles = await _vehicleRepository.GetAllAsync();
                var available = vehicles.Where(v => v.IsAvailable).ToList();

                if (available.Count == 0)
                {
                    _outputPort.EmptyResult();
                    return;
                }

                _outputPort.Standard(new GetAvailableVehiclesOutput(available));
            }
            catch (Exception ex)
            {
                _outputPort.ErrorHandle($"Unexpected error: {ex.Message}");
                throw;
            }
        }
    }
}
