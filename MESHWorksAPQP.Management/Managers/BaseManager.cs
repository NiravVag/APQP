// <copyright file="BaseManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.Interface.ViewModel;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Model.Interface;
    using MESHWorksAPQP.Repository.Interfaces;

    /// <summary>
    /// Class BaseManager.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TSearchCommand">The type of the earch command.</typeparam>
    /// <typeparam name="TSearchResult">The type of the earch result.</typeparam>
    /// <typeparam name="TGetCommand">The type of the get command.</typeparam>
    /// <typeparam name="TGetResult">The type of the get result.</typeparam>
    /// <typeparam name="TSaveCommand">The type of the save command.</typeparam>
    /// <typeparam name="TSaveResult">The type of the save result.</typeparam>
    /// <typeparam name="TFilterVM">The type of the filter vm.</typeparam>
    public abstract class BaseManager<TEntity, TSearchCommand, TSearchResult, TGetCommand, TGetResult, TSaveCommand, TSaveResult, TFilterVM>
    where TEntity : IBaseEntity
    where TSearchCommand : ISearchCommand<TSearchResult, TFilterVM>
    where TGetCommand : IGetCommand<TGetResult>
    where TSaveCommand : ISaveCommand<TSaveResult>
    where TSaveResult : ISaveResult
    where TFilterVM : IFilterVM
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IGenericRepository<TEntity> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseManager{TEntity, TSearchCommand, TSearchResult, TGetCommand, TGetResult, TSaveCommand, TSaveResult, TFilterVM}"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        public BaseManager(
          IMapper mapper,
          IGenericRepository<TEntity> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// bool.
        /// </returns>
        /// <exception cref="ValidationException">Record not found.</exception>
        public virtual async Task<bool> Delete(Guid id)
        {
            var entity = await this.GetEntity(id);
            if (entity == null || entity.IsDeleted)
            {
                throw new ValidationException("Record not found.");
            }

            entity.IsDeleted = true;
            await this.repository.SaveAsync();

            return true;
        }

        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>TGetResult.</returns>
        public virtual async Task<TGetResult> Get(TGetCommand command)
        {
            var entity = await this.GetEntity(command.Id);

            if (entity == null || entity.IsDeleted)
            {
                throw new ValidationException("Record not found.");
            }

            return this.mapper.Map<TGetResult>(entity);
        }

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>TSaveResult.</returns>
        /// <exception cref="ValidationException">Invalid Request.</exception>
        public virtual async Task<TSaveResult> Save(TSaveCommand command)
        {
            if (command.Entity != null)
            {
                TEntity entity;
                if (command.Id != null && command.Id != Guid.Empty)
                {
                    entity = await this.GetEntity(command.Id.Value);

                    if (entity == null || entity.IsDeleted)
                    {
                        throw new ValidationException("Record not found.");
                    }

                    this.mapper.Map(command.Entity, entity);
                    this.SetUpdateEntity(command, entity);
                    await this.ValidatUpdateEntity(command, entity);
                    this.repository.Update(entity);
                }
                else
                {
                    entity = this.mapper.Map<TEntity>(command.Entity);
                    this.SetCreateEntity(command, entity);
                    await this.ValidateCreateEntity(command, entity);
                    this.repository.Create(entity);
                }

                await this.repository.SaveAsync();

                command.Entity.Id = entity.Id;

                return command.Entity;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Page of TSearchResult.</returns>
        public virtual Task<Page<TSearchResult>> Search(TSearchCommand command)
        {
            var query = this.repository.GetAll();

            if (command.Filter.IsDeleted.HasValue && command.Filter.IsDeleted == true)
            {
                query = query.Where(x => x.IsDeleted);
            }
            else
            {
                query = query.Where(x => !x.IsDeleted);
            }

            query = this.FilterData(command, query);

            var size = query.Count();

            if (command.Filter?.SortingOption != null && !string.IsNullOrWhiteSpace(command.Filter.SortingOption.SortBy) && !string.IsNullOrWhiteSpace(command.Filter.SortingOption.SortOrder))
            {
                this.SetSortBy(command);

                query = query.OrderBy($"{command.Filter.SortingOption.SortBy} {command.Filter.SortingOption.SortOrder}");
            }

            var limit = command.Filter.PagingOption?.Limit ?? (size == 0 ? 1 : size);
            var skip = (command.Filter.PagingOption?.Offset ?? 0) * limit;
            var items = query
               .Skip(skip)
               .Take(limit)
               .ProjectTo<TSearchResult>(this.mapper.ConfigurationProvider).ToList();

            return Task.FromResult(new Page<TSearchResult>()
            {
                Items = items,
                TotalSize = size,
            });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseManager{TEntity, TSearchCommand, TSearchResult, TGetCommand, TGetResult, TSaveCommand, TSaveResult, TFilterVM}" /> class.
        /// </summary>
        /// <param name="command">The command.</param>
        protected virtual void SetSortBy(TSearchCommand command)
        {
        }

        /// <summary>
        /// Filters the data.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="query">The query.</param>
        /// <returns>IQueryable TEntity.</returns>
        protected virtual IQueryable<TEntity> FilterData(TSearchCommand command, IQueryable<TEntity> query)
        {
            return query;
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        /// <exception cref="ValidationException">Record not found.</exception>
        protected virtual async Task<TEntity> GetEntity(Guid id)
        {
            var entity = await this.repository.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new ValidationException("Record not found.");
            }

            return entity;
        }

        /// <summary>
        /// Sets the update entity.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="entity">The entity.</param>
        protected virtual void SetUpdateEntity(TSaveCommand command, TEntity entity)
        {
        }

        /// <summary>
        /// Sets the create entity.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="entity">The entity.</param>
        protected virtual void SetCreateEntity(TSaveCommand command, TEntity entity)
        {
        }

        /// <summary>
        /// Validats the update entity.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Task.
        /// </returns>
        protected virtual async Task ValidatUpdateEntity(TSaveCommand command, TEntity entity)
        {
        }

        /// <summary>
        /// Validates the create entity.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Task.
        /// </returns>
        protected virtual async Task ValidateCreateEntity(TSaveCommand command, TEntity entity)
        {
        }
    }
}
