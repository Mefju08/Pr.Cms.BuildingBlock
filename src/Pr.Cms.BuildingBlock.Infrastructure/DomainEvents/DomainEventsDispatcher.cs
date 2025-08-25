using MediatR;
using Microsoft.EntityFrameworkCore;
using Pr.Cms.BuildingBlock.Domain.Types;
namespace Pr.Cms.BuildingBlock.Infrastructure.DomainEvents
{
    public sealed class DomainEventsDispatcher(
        IPublisher publisher,
        DbContext context) : IDomainEventsDispatcher
    {
        public async Task DispatchAsync()
        {
            var events = context.ChangeTracker
                 .Entries<AggregateRoot>()
                 .Select(x => x.Entity)
                 .SelectMany(x =>
                 {
                     var events = x.DomainEvents.ToList();
                     x.ClearDomainEvents();
                     return events;

                 }).ToList();

            foreach (var @event in events)
            {
                await publisher.Publish(@event);
            }

            await Task.CompletedTask;
        }
    }
}
