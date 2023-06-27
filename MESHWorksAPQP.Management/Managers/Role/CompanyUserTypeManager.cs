// <copyright file="CompanyUserTypeManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Role
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Commands.Role.CompanyUserType;
    using MESHWorksAPQP.Management.Interface.Managers.Role;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Company.CompanyUserType;
    using MESHWorksAPQP.Management.ViewModel.User.CompanyUserType;
    using MESHWorksAPQP.Model.Models.Role;
    using MESHWorksAPQP.Repository.Interfaces;

    /// <summary>
    /// Class CompanyUserTypeManager.
    /// </summary>
    public class CompanyUserTypeManager : BaseManager<CompanyUserType, SearchCompanyUserTypeCommand, CompanyUserTypeListVM, GetCompanyUserTypeCommand, CompanyUserTypeVM, SaveCompanyUserTypeCommand, CompanyUserTypeVM, FilterVM>, ICompanyUserTypeManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IGenericRepository<CompanyUserType> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyUserTypeManager" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        public CompanyUserTypeManager(
           IMapper mapper,
           IGenericRepository<CompanyUserType> repository)
            : base(mapper, repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// CompanyUserTypeVM.
        /// </returns>
        /// <exception cref="ValidationException">Invalid Request.</exception>
        public override async Task<CompanyUserTypeVM> Get(GetCompanyUserTypeCommand command)
        {
            var entity = await this.GetEntity(command.Id);

            if (entity != null && command.Id != Guid.Empty)
            {
                return this.mapper.Map<CompanyUserTypeVM>(entity);
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>CompanyUserTypeVM.</returns>
        /// <exception cref="ValidationException">Invalid CompanyUserType.</exception>
        /// <exception cref="ValidationException">Invalid Request.</exception>
        public override async Task<CompanyUserTypeVM> Save(SaveCompanyUserTypeCommand command)
        {
            if (command.Entity != null && command.Id != Guid.Empty)
            {
                var companyUserType = await this.GetEntity(command.Id.Value);
                if (companyUserType == null)
                {
                    throw new ValidationException("Invalid CompanyUserType.");
                }

                this.mapper.Map(command.Entity, companyUserType);
                this.repository.Update(companyUserType);
                await this.repository.SaveAsync();
                return command.Entity;
            }
            else
            {
                var entity = this.mapper.Map<CompanyUserType>(command.Entity);
                this.repository.Create(entity);
                await this.repository.SaveAsync();
                return command.Entity;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// bool.
        /// </returns>
        /// <exception cref="ValidationException">Invalid CompanyUserType.</exception>
        public async Task<bool> Delete(DeleteCompanyUserTypeCommand command)
        {
            var companyUserType = await this.GetEntity(command.Id);

            if (companyUserType != null && command.Id != Guid.Empty)
            {
                if (companyUserType.IsSystemCreated)
                {
                    throw new ValidationException("Not allowed to syetem created user type.");
                }

                companyUserType.IsDeleted = true;
                this.repository.Update(companyUserType);

                await this.repository.SaveAsync();
                return true;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Page of CompanyUserTypeListVM.</returns>
        /// <exception cref="ValidationException">Invalid Request.</exception>
        public override async Task<Page<CompanyUserTypeListVM>> Search(SearchCompanyUserTypeCommand command)
        {
            if (command.CompanyId != Guid.Empty)
            {
                var companyUserTypes = this.repository.GetAll(x => x.CompanyId == command.CompanyId && !x.IsDeleted);

                if (companyUserTypes != null)
                {
                    if (!string.IsNullOrWhiteSpace(command.Filter?.SearchText))
                    {
                        companyUserTypes = companyUserTypes.Where(x => x.Name.Contains(command.Filter.SearchText));
                    }

                    var size = companyUserTypes.Count();

                    if (command.Filter?.SortingOption != null && !string.IsNullOrWhiteSpace(command.Filter.SortingOption.SortBy) && !string.IsNullOrWhiteSpace(command.Filter.SortingOption.SortOrder))
                    {
                        companyUserTypes = companyUserTypes.OrderBy($"{command.Filter.SortingOption.SortBy} {command.Filter.SortingOption.SortOrder}");
                    }

                    var limit = command.Filter.PagingOption?.Limit ?? (size == 0 ? 1 : size);
                    var skip = (command.Filter.PagingOption?.Offset ?? 0) * limit;
                    var items = companyUserTypes
                       .Skip(skip)
                       .Take(limit)
                       .ProjectTo<CompanyUserTypeListVM>(this.mapper.ConfigurationProvider).ToList();

                    return await Task.FromResult(new Page<CompanyUserTypeListVM>()
                    {
                        Items = items,
                        TotalSize = size,
                    });
                }
            }

            throw new ValidationException("Invalid Request.");
        }
    }
}
