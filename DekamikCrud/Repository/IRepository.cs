using DekamikCrud.Entities;
using DekamikCrud.ReadOnlyRepository;
using System;

namespace DekamikCrud.Repository
{
    /// <summary>
    /// A CRUD-repository for Creating, Reading, Updating and Deleting any entity inheriting from <see cref="BaseEntity"/> in the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Creates a new entity in the database.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        void Create(TEntity entity);

        /// <summary>
        /// Creates all entities in the database.
        /// </summary>
        /// <param name="entities">The entities to create.</param>
        void Create(params TEntity[] entities);

        /// <summary>
        /// Updates the entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Updates all entities in the database.
        /// </summary>
        /// <param name="entities"></param>
        void Update(params TEntity[] entities);

        /// <summary>
        /// Deletes the entity with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Id of entity to delete.</param>
        /// <exception cref="NullReferenceException">Thrown if entity not found.</exception>
        void Delete(int id);

        /// <summary>
        /// Deletes all entities that matches the specified <paramref name="ids"/>.
        /// </summary>
        /// <param name="ids">Ids of entities to delete</param>
        /// <exception cref="NullReferenceException">Thrown if no entity found.</exception>
        void Delete(params int[] ids);

        /// <summary>
        /// Commits all changes made in the Repository to the underlying database.
        /// This is done automatically if AutoSave is set to true.
        /// </summary>
        void SaveChanges();
    }
}
