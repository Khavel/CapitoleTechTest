using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Fakes
{
    /// <summary>
    /// Fake implementation of the UnitOfWork for testing purposes.
    /// </summary>
    public sealed class FakeUnitOfWork : IUnitOfWork
    {
        /// <inheritdoc />
        public Task<int> Save()
        {
            // Simulate a successful save operation.
            return Task.FromResult(1);
        }
    }
}
