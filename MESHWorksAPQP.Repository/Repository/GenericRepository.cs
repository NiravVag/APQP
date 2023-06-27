// <copyright file="GenericRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Interface;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.Extensions;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Shared;
    using MESHWorksAPQP.Shared.Interface;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class GenericRepository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.IGenericRepository{TEntity}" />
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
       where TEntity : class, IBaseEntity
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// The entities.
        /// </summary>
        private DbSet<TEntity> entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userIdentity">The user identity.</param>
        public GenericRepository(ApplicationDbContext context, IUserIdentity userIdentity)
        {
            this.context = context;
            this.userIdentity = userIdentity;
            this.entities = context.Set<TEntity>();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// IQueryable TEntity.
        /// </returns>
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = this.entities;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        /// <summary>
        /// Firsts the or default asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// Task TEntity.
        /// </returns>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await this.entities.FirstOrDefaultAsync(filter);
        }

        /// <summary>
        /// Gets the exists.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// Task bool.
        /// </returns>
        public async Task<bool> GetExists(Expression<Func<TEntity, bool>> filter)
        {
            return await this.entities.AnyAsync(filter);
        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Task TEntity.
        /// </returns>
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await this.entities.FindAsync(id);
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException">entity.</exception>
        public void Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.entities.Add(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException">entity.</exception>
        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.entities.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(Guid id)
        {
            TEntity entityToDelete = this.entities.Find(id);
            if (this.context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.entities.Attach(entityToDelete);
            }

            this.entities.Remove(entityToDelete);
        }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <param name="createdBy">The created by.</param>
        /// <returns>
        /// Task.
        /// </returns>
        public async Task SaveAsync(string createdBy = null)
        {
            var modifiedEntries = this.context.ChangeTracker.Entries<IAuditable>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var auditableEntity in modifiedEntries)
            {
                if (auditableEntity.State == EntityState.Added ||
                    auditableEntity.State == EntityState.Modified)
                {
                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.Created = DateTime.UtcNow;

                        if (this.userIdentity?.UserInfo != null)
                        {
                            auditableEntity.Entity.CreatedBy = this.userIdentity.UserInfo.FullName;
                        }
                        else
                        {
                            auditableEntity.Entity.CreatedBy = "Admin";
                        }
                    }
                    else
                    {
                        auditableEntity.Entity.LastModified = DateTime.UtcNow;

                        if (this.userIdentity?.UserInfo != null)
                        {
                            auditableEntity.Entity.LastModifiedBy = this.userIdentity.UserInfo.FullName;
                        }
                        else
                        {
                            auditableEntity.Entity.LastModifiedBy = "Admin";
                        }
                    }
                }
            }

            await this.context.SaveChangesAsync();
        }
    }
}
