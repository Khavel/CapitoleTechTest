using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.GetAvailableVehicles
{
    /// <summary>
    /// Empty request for listing available vehicles.
    /// </summary>
    public sealed class GetAvailableVehiclesRequest : IRequest<IWebApiPresenter>
    {
    }
}
