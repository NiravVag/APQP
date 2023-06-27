// <copyright file="PageTypeManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Setup.PageType
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Command.Setup.PageType;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.PageType;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Management.ViewModel.Setup.PageType;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;

    /// <summary>
    /// Class IPageTypeManager.
    /// </summary>
    public class PageTypeManager : SetupBaseManager<PageType, SearchPageTypeCommand, SetupListVM, GetPageTypeCommand, SetupVM, SavePageTypeCommand, PageTypeVM, PageTypeFilterVM>, IPageTypeManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ISetupRepositoty<PageType> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageTypeManager"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        public PageTypeManager(
            IMapper mapper,
            ISetupRepositoty<PageType> repository)
             : base(mapper, repository)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Filters the data.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="query">The query.</param>
        /// <returns>
        /// IQueryable TEntity.
        /// </returns>
        protected override IQueryable<PageType> FilterData(SearchPageTypeCommand command, IQueryable<PageType> query)
        {
            if (command?.Filter?.PageTypeId != null && command.Filter.PageTypeId.HasValue)
            {
                query = query.Where(x => x.Id == (Guid)command.Filter.PageTypeId);
            }

            query = base.FilterData(command, query);

            return query;
        }
    }
}
