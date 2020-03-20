using Microsoft.EntityFrameworkCore;
using DekamikCrud.Entities;
using DekamikCrud.ReadOnlyRepository;
using System;
using System.Linq;

namespace DekamikCrud.Repository
{
    /// <inheritdoc/>
    /// <typeparam name="TDbContext">The <see cref="DbContext"/>.</typeparam>
    public abstract class BaseRepository<TDbContext, TEntity> : BaseReadOnlyRepository<TDbContext, TEntity>, IRepository<TEntity>
        where TEntity : BaseEntity
        where TDbContext : DbContext
    {
        private DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

        /// <summary>
        /// If true the repository commits each change to the database immediately.
        /// </summary>
        public bool AutoSave { get; set; } = true;

        public BaseRepository(TDbContext dbContext) : base(dbContext)
        {
        }

        /// <inheritdoc/>
        public virtual void Create(TEntity entity)
        {
            DbSet.Add(entity);
            if (AutoSave)
            {
                SaveChanges();
            }
        }

        /// <inheritdoc/>
        public virtual void Create(params TEntity[] entities)
        {
            DbSet.AddRange(entities);
            if (AutoSave)
            {
                SaveChanges();
            }
        }

        /// <inheritdoc/>
        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
            if (AutoSave)
            {
                SaveChanges();
            }
        }

        /// <inheritdoc/>
        public virtual void Update(params TEntity[] entities)
        {
            DbSet.UpdateRange(entities);
            if (AutoSave)
            {
                SaveChanges();
            }
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            TEntity entity = Get(id);
            if (entity == null)
            {
                throw new NullReferenceException($"{typeof(TEntity)} with Id {id} not found when attempting delete.");
            }

            DbSet.Remove(entity);

            if (AutoSave)
            {
                SaveChanges();
            }
        }

        /// <inheritdoc/>
        public void Delete(params int[] ids)
        {
            IQueryable<TEntity> entities = Get(ids);
            if (entities.Count() == 0)
            {
                throw new NullReferenceException($"No {typeof(TEntity)} with any Id in {string.Join(", ", ids)} not found when attempting delete.");
            }

            DbSet.RemoveRange(entities);

            if (AutoSave)
            {
                SaveChanges();
            }
        }

        /// <inheritdoc/>
        public void SaveChanges() => _dbContext.SaveChanges();
    }
}
