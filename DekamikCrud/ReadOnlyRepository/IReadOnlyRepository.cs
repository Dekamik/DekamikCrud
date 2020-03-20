using DekamikCrud.Entities;
using System.Linq;

namespace DekamikCrud.ReadOnlyRepository
{
    /// <summary>
    /// A read-only repository for fetching entities inheriting from <see cref="BaseEntity"/> in a database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    public interface IReadOnlyRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Returns all entities in the database.
        /// </summary>
        /// <returns>Empty <see cref="IQueryable"/> if no entities found.</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Returns the entity with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Null if not found.</returns>
        TEntity Get(int id);

        /// <summary>
        /// Returns all entities that matches the specified <paramref name="ids"/>.
        /// </summary>
        /// <param name="ids">List of identifiers to match.</param>
        /// <returns>Empty <see cref="IQueryable"/> if entities not found.</returns>
        IQueryable<TEntity> Get(params int[] ids);
    }
}
