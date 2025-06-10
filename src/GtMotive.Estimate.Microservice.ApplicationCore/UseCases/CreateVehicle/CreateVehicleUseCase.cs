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

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
        /// </summary>
        /// <param name="repository">The vehicle repository.</param>
        /// <param name="unitOfWork">The unit of work for transaction handling.</param>
        /// <param name="output">The output presenter.</param>
        public CreateVehicleUseCase(
            IVehicleRepository repository,
            IUnitOfWork unitOfWork,
            ICreateVehicleOutputPort output)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _output = output;
        }

        /// <inheritdoc/>
        public async Task Execute(CreateVehicleInput input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var vehicle = new Vehicle(
                new VehicleId(Guid.NewGuid()),
                input.Brand,
                input.Model,
                new Year(input.Year));

            if (!vehicle.IsEligibleForFleet())
            {
                _output.VehicleRejected("The vehicle is too old for the fleet (max 5 years).");
                return;
            }

            await _repository.AddAsync(vehicle);
            await _unitOfWork.Save();

            _output.Standard(new CreateVehicleOutput(vehicle.Id));
        }
    }
}
