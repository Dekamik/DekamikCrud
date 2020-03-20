using Microsoft.EntityFrameworkCore;
using DekamikCrud.Entities;
using System.Linq;

namespace DekamikCrud.ReadOnlyRepository
{
    /// <inheritdoc/>
    /// <typeparam name="TDbContext">The <see cref="DbContext"/>.</typeparam>
    public abstract class BaseReadOnlyRepository<TDbContext, TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : BaseEntity
        where TDbContext : DbContext
    {
        internal readonly TDbContext _dbContext;

        public BaseReadOnlyRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public TEntity Get(int id) => GetAll().FirstOrDefault(e => e.Id == id);

        /// <inheritdoc/>
        public IQueryable<TEntity> Get(params int[] ids) => GetAll().Where(e => ids.Contains(e.Id));

        /// <inheritdoc/>
        public IQueryable<TEntity> GetAll() => _dbContext.Set<TEntity>().AsNoTracking();
    }
}
