// <copyright file="IGenericRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Interface;

    /// <summary>
    /// Interface IGenericRepository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGenericRepository<TEntity>
    where TEntity : IBaseEntity
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>IQueryable TEntity.</returns>
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Firsts the or default asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Task TEntity.</returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Gets the exists.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// Task bool.
        /// </returns>
        Task<bool> GetExists(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task TEntity.</returns>
        Task<TEntity> GetByIdAsync(Guid id);

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Create(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(Guid id);

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <param name="createdBy">The created by.</param>
        /// <returns>
        /// Task.
        /// </returns>
        Task SaveAsync(string createdBy = null);
    }
}
