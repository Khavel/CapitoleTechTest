using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.GetAvailableVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAvailableVehicles
{
    /// <summary>
    /// Handles MediatR request to get available vehicles.
    /// </summary>
    public sealed class GetAvailableVehiclesRequestHandler : IRequestHandler<GetAvailableVehiclesRequest, IWebApiPresenter>
    {
        private readonly IUseCase<GetAvailableVehiclesInput> _useCase;
        private readonly GetAvailableVehiclesPresenter _presenter;

        public GetAvailableVehiclesRequestHandler(
            IUseCase<GetAvailableVehiclesInput> useCase,
            GetAvailableVehiclesPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task<IWebApiPresenter> Handle(GetAvailableVehiclesRequest request, CancellationToken cancellationToken)
        {
            await _useCase.Execute(null!);
            return _presenter;
        }
    }
}
