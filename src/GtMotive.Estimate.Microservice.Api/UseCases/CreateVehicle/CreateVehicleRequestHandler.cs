using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    /// <summary>
    /// Handles the CreateVehicleRequest by invoking the use case and returning the presenter.
    /// </summary>
    public sealed class CreateVehicleRequestHandler : IRequestHandler<CreateVehicleRequest, IWebApiPresenter>
    {
        private readonly IUseCase<CreateVehicleInput> _useCase;
        private readonly CreateVehiclePresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleRequestHandler"/> class.
        /// </summary>
        /// <param name="useCase">The CreateVehicle use case.</param>
        /// <param name="presenter">The presenter to format the result.</param>
        public CreateVehicleRequestHandler(
            IUseCase<CreateVehicleInput> useCase,
            CreateVehiclePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        /// <inheritdoc/>
        public async Task<IWebApiPresenter> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var input = new CreateVehicleInput
            {
                Brand = request.Brand,
                Model = request.Model,
                Year = request.Year
            };

            await _useCase.Execute(input);
            return _presenter;
        }
    }
}
