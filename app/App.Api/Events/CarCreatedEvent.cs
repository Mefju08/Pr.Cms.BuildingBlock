using MediatR;
using Pr.Cms.BuildingBlock.Domain.Events;

namespace App.Api.Events
{
    public record CarCreatedEvent(
        string Name) : DomainEvent;

    public sealed class CarCreatedEventHandler : INotificationHandler<CarCreatedEvent>
    {
        public async Task Handle(CarCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Succes");
            await Task.CompletedTask;
        }
    }
}
