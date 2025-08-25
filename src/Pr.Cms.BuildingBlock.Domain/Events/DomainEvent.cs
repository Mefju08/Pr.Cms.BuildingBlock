using Pr.Cms.BuildingBlock.Domain.Time;

namespace Pr.Cms.BuildingBlock.Domain.Events
{
    public abstract record DomainEvent : IDomainEvent
    {
        public Guid Id { get; }
        public DateTime OccurredOn { get; }

        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = Clock.UtcNow;
        }

        protected DomainEvent(IDateTimeProvider dateTimeProvider)
        {
            Id = Guid.NewGuid();
            OccurredOn = dateTimeProvider.UtcNow;
        }
    }
}
