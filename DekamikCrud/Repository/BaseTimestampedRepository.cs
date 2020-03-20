using DekamikCrud.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DekamikCrud.Repository
{
    public abstract class BaseTimestampedRepository<TDbContext, TEntity> : BaseRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : BaseTimestampedEntity
    {
        public BaseTimestampedRepository(TDbContext dbContext) : base(dbContext)
        {
        }

        public override void Create(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            base.Create(entity);
        }

        public override void Create(params TEntity[] entities)
        {
            DateTime now = DateTime.Now;
            Array.ForEach(entities, e => e.CreatedAt = now);
            base.Create(entities);
        }

        public override void Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            base.Update(entity);
        }

        public override void Update(params TEntity[] entities)
        {
            DateTime now = DateTime.Now;
            Array.ForEach(entities, e => e.UpdatedAt = now);
            base.Update(entities);
        }
    }
}
