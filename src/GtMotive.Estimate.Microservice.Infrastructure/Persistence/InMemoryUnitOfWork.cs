using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.Persistence
{
    /// <summary>
    /// In-memory Unit of Work. Does nothing by design.
    /// </summary>
    public sealed class InMemoryUnitOfWork : IUnitOfWork
    {
        /// <inheritdoc/>
        public Task<int> Save()
        {
            // Always "succeeds" in memory
            return Task.FromResult(1);
        }
    }
}
