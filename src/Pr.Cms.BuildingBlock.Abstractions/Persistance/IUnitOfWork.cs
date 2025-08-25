namespace Pr.Cms.BuildingBlock.Abstractions.Persistance
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
