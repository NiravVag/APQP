// <copyright file="SetupBaseManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Setup
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.Interface.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Model.Interface;
    using MESHWorksAPQP.Repository.Interfaces;

    /// <summary>
    /// Class SetupBaseManager.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TSearchCommand">The type of the search command.</typeparam>
    /// <typeparam name="TSearchResult">The type of the search result.</typeparam>
    /// <typeparam name="TGetCommand">The type of the get command.</typeparam>
    /// <typeparam name="TGetResult">The type of the get result.</typeparam>
    /// <typeparam name="TSaveCommand">The type of the save command.</typeparam>
    /// <typeparam name="TSaveResult">The type of the save result.</typeparam>
    /// <typeparam name="TFilterVM">The type of the filter vm.</typeparam>
    public abstract class SetupBaseManager<TEntity, TSearchCommand, TSearchResult, TGetCommand, TGetResult, TSaveCommand, TSaveResult, TFilterVM> : BaseManager<TEntity, TSearchCommand, TSearchResult, TGetCommand, TGetResult, TSaveCommand, TSaveResult, TFilterVM>
             where TEntity : ISetupBaseEntity
             where TSearchCommand : ISearchCommand<TSearchResult, TFilterVM>
             where TGetCommand : IGetCommand<TGetResult>
             where TSaveCommand : ISaveCommand<TSaveResult>
             where TSaveResult : SetupVM, ISaveResult
             where TFilterVM : IFilterVM
    {
        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ISetupRepositoty<TEntity> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetupBaseManager{TEntity, TSearchCommand, TSearchResult, TGetCommand, TGetResult, TSaveCommand, TSaveResult, TFilterVM}"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        public SetupBaseManager(
          IMapper mapper,
          ISetupRepositoty<TEntity> repository)
            : base(mapper, repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// </summary>
        /// <param name="command">The command.</param>
        protected override void SetSortBy(TSearchCommand command)
        {
        }

        /// <summary>
        /// Filters the data.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="query">The query.</param>
        /// <returns>
        /// IQueryable TEntity.
        /// </returns>
        protected override IQueryable<TEntity> FilterData(TSearchCommand command, IQueryable<TEntity> query)
        {
            if (!string.IsNullOrWhiteSpace(command.Filter?.SearchText))
            {
                query = query.Where(x => x.Name.Contains(command.Filter.SearchText));
            }

            return query;
        }

        /// <summary>
        /// Validats the update entity.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Task.
        /// </returns>
        protected override async Task ValidatUpdateEntity(TSaveCommand command, TEntity entity)
        {
            if (await this.repository.GetExists(x => !x.IsDeleted && x.Id != command.Id.Value && x.Code == command.Entity.Code))
            {
                throw new ValidationException("Code already exist.");
            }
        }

        /// <summary>
        /// Validates the create entity.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Task.
        /// </returns>
        protected override async Task ValidateCreateEntity(TSaveCommand command, TEntity entity)
        {
            if (await this.repository.GetExists(x => !x.IsDeleted && x.Code == command.Entity.Code))
            {
                throw new ValidationException("Code already exist.");
            }
        }
    }
}
