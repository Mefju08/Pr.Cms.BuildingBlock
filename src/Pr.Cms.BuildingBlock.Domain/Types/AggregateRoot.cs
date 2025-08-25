using Pr.Cms.BuildingBlock.Domain.Events;

namespace Pr.Cms.BuildingBlock.Domain.Types
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        public int Version { get; private set; }
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();


        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            ArgumentNullException.ThrowIfNull(domainEvent);
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
            => _domainEvents.Clear();

        protected void IncrementVersion()
            => Version++;
    }


}
