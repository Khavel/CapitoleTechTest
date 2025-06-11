using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    /// <summary>
    /// Handles the ReturnVehicleRequest by invoking the use case and returning the presenter.
    /// </summary>
    public sealed class ReturnVehicleRequestHandler : IRequestHandler<ReturnVehicleRequest, IWebApiPresenter>
    {
        private readonly IUseCase<ReturnVehicleInput> _useCase;
        private readonly ReturnVehiclePresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleRequestHandler"/> class.
        /// </summary>
        /// <param name="useCase">The ReturnVehicle use case.</param>
        /// <param name="presenter">The presenter to format the result.</param>
        public ReturnVehicleRequestHandler(
            IUseCase<ReturnVehicleInput> useCase,
            ReturnVehiclePresenter presenter)
        {
            _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        }

        /// <inheritdoc/>
        public async Task<IWebApiPresenter> Handle(ReturnVehicleRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!Guid.TryParse(request.VehicleId, out var vehicleGuid))
            {
                throw new ArgumentException("Invalid format for VehicleId");
            }

            var input = new ReturnVehicleInput(new VehicleId(vehicleGuid));

            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
