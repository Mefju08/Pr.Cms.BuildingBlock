using Pr.Cms.BuildingBlock.Domain.Types;

namespace Pr.Cms.BuildingBlock.Abstractions.Persistance
{
    public interface IGenericRepository<TEntity, TId>
        where TEntity : Entity
        where TId : TypedId
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}