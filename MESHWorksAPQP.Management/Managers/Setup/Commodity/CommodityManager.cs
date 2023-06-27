// <copyright file="CommodityManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Setup.Commodity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Command.Setup.Commodity;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Commodity;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.Setup;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class CommodityManager.
    /// </summary>
    public class CommodityManager : SetupBaseManager<Commodity, SearchCommodityCommand, SetupListVM, GetCommodityCommand, SetupVM, SaveCommodityCommand, SetupVM, SetupFilterVM>, ICommodityManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ISetupRepositoty<Commodity> repository;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommodityManager"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="userIdentity">The userIdentity.</param>
        public CommodityManager(
            IMapper mapper,
            ISetupRepositoty<Commodity> repository,
            IUserIdentity userIdentity)
             : base(mapper, repository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userIdentity = userIdentity;
        }

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>TSaveResult.</returns>
        /// <exception cref="ValidationException">Invalid Request.</exception>
        public async Task<SetupVM> Save(SaveCommodityCommand command)
        {
            if (command.Entity != null)
            {
                command.Entity.CompanyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.Entity.CompanyId ?? default(Guid);

                Commodity entity;
                if (command.Id != null && command.Id != Guid.Empty)
                {
                    entity = await this.GetEntity(command.Id.Value);

                    if (entity == null || entity.IsDeleted)
                    {
                        throw new ValidationException("Record not found.");
                    }

                    this.mapper.Map(command.Entity, entity);
                    this.SetUpdateEntity(command, entity);
                    var commodity = this.repository.GetAll().Where(x => !x.IsDeleted && x.Id != command.Id.Value && x.Code == command.Entity.Code && x.CompanyId == command.Entity.CompanyId).FirstOrDefault();
                    if (commodity != null)
                    {
                        throw new ValidationException("Code already exist.");
                    }

                    this.repository.Update(entity);
                }
                else
                {
                    entity = this.mapper.Map<Commodity>(command.Entity);
                    this.SetCreateEntity(command, entity);
                    var commodity = this.repository.GetAll().Where(x => !x.IsDeleted && x.Code == command.Entity.Code && x.CompanyId == command.Entity.CompanyId).FirstOrDefault();
                    if (commodity != null)
                    {
                        throw new ValidationException("Code already exist.");
                    }

                    //  await this.ValidateCreateEntity(command, entity);
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
        public virtual Task<Page<SetupListVM>> Search(SearchCommodityCommand command)
        {
            var companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.Filter.CompanyId ?? default(Guid);

            var query = this.repository.GetAll(x => !x.IsDeleted && x.CompanyId == companyId);

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
               .ProjectTo<SetupListVM>(this.mapper.ConfigurationProvider).ToList();

            return Task.FromResult(new Page<SetupListVM>()
            {
                Items = items,
                TotalSize = size,
            });
        }
    }
}
