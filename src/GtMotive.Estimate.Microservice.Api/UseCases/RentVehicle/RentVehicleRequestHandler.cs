using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentVehicle
{
    /// <summary>
    /// Handles the RentVehicleRequest by invoking the use case and returning the presenter.
    /// </summary>
    public sealed class RentVehicleRequestHandler : IRequestHandler<RentVehicleRequest, IWebApiPresenter>
    {
        private readonly IUseCase<RentVehicleInput> _useCase;
        private readonly RentVehiclePresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleRequestHandler"/> class.
        /// </summary>
        /// <param name="useCase">The RentVehicle use case.</param>
        /// <param name="presenter">The presenter to format the result.</param>
        public RentVehicleRequestHandler(
            IUseCase<RentVehicleInput> useCase,
            RentVehiclePresenter presenter)
        {
            _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        }

        /// <inheritdoc/>
        public async Task<IWebApiPresenter> Handle(RentVehicleRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!Guid.TryParse(request.VehicleId, out var vehicleGuid))
            {
                throw new ArgumentException("Invalid format for VehicleId");
            }

            if (!Guid.TryParse(request.CustomerId, out var customerGuid))
            {
                throw new ArgumentException("Invalid format for CustomerId");
            }

            var input = new RentVehicleInput(
                new VehicleId(vehicleGuid),
                new CustomerId(customerGuid));

            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
