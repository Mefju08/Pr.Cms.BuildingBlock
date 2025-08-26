using Pr.Cms.BuildingBlock.Domain.Events;

namespace App.Api.Events
{
    public record UserRegisteredEvent(
        string Name) : DomainEvent;
}
