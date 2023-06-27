// <copyright file="MaterialTypeManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Setup.MaterialType
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Command.Setup.MaterialType;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.MaterialType;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.Setup;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class MaterialTypeManager.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Managers.Setup.SetupBaseManager{MESHWorksAPQP.Model.Models.Setup.MaterialType, MESHWorksAPQP.Management.Command.Setup.MaterialType.SearchMaterialTypeCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupListVM, MESHWorksAPQP.Management.Command.Setup.MaterialType.GetMaterialTypeCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.Command.Setup.MaterialType.SaveMaterialTypeCommand, MESHWorksAPQP.Management.ViewModel.Setup.SetupVM, MESHWorksAPQP.Management.ViewModel.Setup.MaterialFilterVM}" />
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Managers.Setup.MaterialType.IMaterialTypeManager" />
    public class MaterialTypeManager : SetupBaseManager<MaterialType, SearchMaterialTypeCommand, SetupListVM, GetMaterialTypeCommand, MaterialVM, SaveMaterialTypeCommand, MaterialVM, MaterialFilterVM>, IMaterialTypeManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ISetupRepositoty<MaterialType> repository;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialTypeManager"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="userIdentity">The userIdentity.</param>
        public MaterialTypeManager(
            IMapper mapper,
            ISetupRepositoty<MaterialType> repository,
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
        /// <returns>MaterialVM.</returns>
        public async Task<MaterialVM> Save(SaveMaterialTypeCommand command)
        {
            if (command.Entity != null)
            {
                command.Entity.CompanyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.Entity.CompanyId ?? default(Guid);

                MaterialType entity;
                if (command.Id != null && command.Id != Guid.Empty)
                {
                    entity = await this.GetEntity(command.Id.Value);

                    if (entity == null || entity.IsDeleted)
                    {
                        throw new ValidationException("Record not found.");
                    }

                    this.mapper.Map(command.Entity, entity);
                    this.SetUpdateEntity(command, entity);
                    var materialType = this.repository.GetAll().Where(x => !x.IsDeleted && x.Id != command.Id.Value && x.Code == command.Entity.Code && x.CompanyId == command.Entity.CompanyId).FirstOrDefault();
                    if (materialType != null)
                    {
                        throw new ValidationException("Code already exist.");
                    }

                   // await this.ValidatUpdateEntity(command, entity);
                    this.repository.Update(entity);
                }
                else
                {
                    entity = this.mapper.Map<MaterialType>(command.Entity);
                    this.SetCreateEntity(command, entity);
                    var materialType = this.repository.GetAll().Where(x => !x.IsDeleted && x.Code == command.Entity.Code && x.CompanyId == command.Entity.CompanyId).FirstOrDefault();
                    if (materialType != null)
                    {
                        throw new ValidationException("Code already exist.");
                    }

                   // await this.ValidateCreateEntity(command, entity);
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
        public virtual Task<Page<SetupListVM>> Search(SearchMaterialTypeCommand command)
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

        /// <summary>
        /// Filters the data.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="query">The query.</param>
        /// <returns>
        /// IQueryable TEntity.
        /// </returns>
        protected override IQueryable<MaterialType> FilterData(SearchMaterialTypeCommand command, IQueryable<MaterialType> query)
        {
            if (command?.Filter?.CommodityId != null && command.Filter.CommodityId.HasValue)
            {
                query = query.Where(x => x.CommodityId == (Guid)command.Filter.CommodityId);
            }

            query = base.FilterData(command, query);

            return query;
        }
    }
}
