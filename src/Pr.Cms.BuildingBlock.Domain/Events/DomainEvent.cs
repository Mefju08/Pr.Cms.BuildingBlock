using Pr.Cms.BuildingBlock.Domain.Time;

namespace Pr.Cms.BuildingBlock.Domain.Events
{
    /// <summary>
    /// Abstrakcyjna klasa bazowa dla wszystkich wydarzeń domenowych w systemie.
    /// Automatycznie generuje unikalny identyfikator i znacznik czasu wystąpienia wydarzenia.
    /// </summary>
    public abstract record DomainEvent : IDomainEvent
    {
        public Guid Id { get; }
        public DateTimeOffset OccurredOn { get; }

        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = Clock.Now;
        }

        protected DomainEvent(IDateTimeProvider dateTimeProvider)
        {
            Id = Guid.NewGuid();
            OccurredOn = dateTimeProvider.Now;
        }
    }
}
