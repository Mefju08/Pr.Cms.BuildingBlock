using Microsoft.EntityFrameworkCore;
using Pr.Cms.BuildingBlock.Abstractions.Persistance;
using Pr.Cms.BuildingBlock.Domain.Types;
namespace Pr.Cms.BuildingBlock.Infrastructure.Persistance.Repositories
{
    public class Repository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : Entity
        where TId : TypedId
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(id);
            return await _dbSet.FindAsync([id], cancellationToken);
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public virtual async Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(id);
            return await _dbSet.FindAsync([id], cancellationToken) != null;
        }
    }
}
