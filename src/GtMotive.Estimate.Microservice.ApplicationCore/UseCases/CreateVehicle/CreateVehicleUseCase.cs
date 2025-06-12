using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Implements the logic to create a new vehicle.
    /// </summary>
    public class CreateVehicleUseCase : IUseCase<CreateVehicleInput>
    {
        private readonly IVehicleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreateVehicleOutputPort _output;
        private readonly IAppLogger<CreateVehicleUseCase> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
        /// </summary>
        /// <param name="repository">The vehicle repository.</param>
        /// <param name="unitOfWork">The unit of work for transaction handling.</param>
        /// <param name="output">The output presenter.</param>
        /// <param name="logger">The logger.</param>
        public CreateVehicleUseCase(
            IVehicleRepository repository,
            IUnitOfWork unitOfWork,
            ICreateVehicleOutputPort output,
            IAppLogger<CreateVehicleUseCase> logger)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _output = output;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task Execute(CreateVehicleInput input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            _logger.LogInformation(
                                   "Received request to create vehicle: {Brand} {Model} ({Year})",
                                   input.Brand,
                                   input.Model,
                                   input.Year);

            var vehicle = new Vehicle(
                new VehicleId(Guid.NewGuid()),
                input.Brand,
                input.Model,
                new Year(input.Year));

            if (!vehicle.IsEligibleForFleet())
            {
                _logger.LogWarning(
                    "Vehicle rejected due to age: {Brand} {Model} - Year={Year}",
                    input.Brand,
                    input.Model,
                    input.Year);
                _output.VehicleRejected("The vehicle is too old for the fleet (max 5 years).");
                return;
            }

            await _repository.AddAsync(vehicle);
            await _unitOfWork.Save();

            _logger.LogInformation("Vehicle {Id} successfully created", vehicle.Id);

            _output.Standard(new CreateVehicleOutput(vehicle.Id));
        }
    }
}
