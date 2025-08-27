namespace Pr.Cms.BuildingBlock.Core.DomainEvents
{
    public interface IDomainEvent
    {
        Guid Id { get; }
        DateTimeOffset OccurredOn { get; }
    }
}
