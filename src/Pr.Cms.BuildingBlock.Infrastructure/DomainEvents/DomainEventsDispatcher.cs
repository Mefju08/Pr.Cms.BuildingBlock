using Microsoft.EntityFrameworkCore;
using Pr.Cms.BuildingBlock.Domain.Types;
using Wolverine;
namespace Pr.Cms.BuildingBlock.Infrastructure.DomainEvents
{
    internal sealed class DomainEventsDispatcher(
        IMessageContext publisher,
        DbContext context) : IDomainEventsDispatcher
    {
        public async Task DispatchAsync()
        {
            var domainEvents = context.ChangeTracker
                 .Entries<AggregateRoot>()
                 .Select(x => x.Entity)
                 .SelectMany(x =>
                 {
                     var events = x.DomainEvents.ToList();
                     x.ClearDomainEvents();
                     return events;

                 }).ToList();

            foreach (var domainEvent in domainEvents)
            {
                await publisher.PublishAsync(domainEvent);
            }
        }
    }
}
