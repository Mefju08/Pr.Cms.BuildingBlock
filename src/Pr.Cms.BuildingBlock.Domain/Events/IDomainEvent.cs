namespace Pr.Cms.BuildingBlock.Domain.Events
{
    public interface IDomainEvent
    {
        Guid Id { get; }
        DateTimeOffset OccurredOn { get; }
    }
}
