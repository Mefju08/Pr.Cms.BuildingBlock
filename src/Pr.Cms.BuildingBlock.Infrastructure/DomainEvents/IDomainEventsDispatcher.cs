namespace Pr.Cms.BuildingBlock.Infrastructure.DomainEvents
{
    internal interface IDomainEventsDispatcher
    {
        Task DispatchAsync();
    }
}
