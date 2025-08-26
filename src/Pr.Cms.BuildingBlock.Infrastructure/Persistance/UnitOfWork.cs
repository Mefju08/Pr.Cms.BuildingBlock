using Microsoft.EntityFrameworkCore;
using Pr.Cms.BuildingBlock.Abstractions.Repositories;
using Pr.Cms.BuildingBlock.Infrastructure.DomainEvents;

namespace Pr.Cms.BuildingBlock.Infrastructure.Persistance
{
    internal sealed class UnitOfWork(
        IDomainEventsDispatcher domainEventsDispatcher,
        DbContext context) : IUnitOfWork
    {
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            await domainEventsDispatcher.DispatchAsync();
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
