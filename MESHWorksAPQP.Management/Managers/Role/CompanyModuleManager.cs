// <copyright file="CompanyModuleManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Role
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using AutoMapper;
    using MESHWorksAPQP.Management.Commands.Role.CompanyModule;
    using MESHWorksAPQP.Management.Interface.Managers.Role;
    using MESHWorksAPQP.Model.Models.Role;
    using MESHWorksAPQP.Repository.CustomModel;
    using MESHWorksAPQP.Repository.Interfaces;

    /// <summary>
    /// Class CompanyModuleManager.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Managers.Company.ICompanyModuleManager" />
    public class CompanyModuleManager : ICompanyModuleManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IGenericRepository<CompanyModule> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyModuleManager"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        public CompanyModuleManager(
           IMapper mapper,
           IGenericRepository<CompanyModule> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List Of CompanyModuleDetail.
        /// </returns>
        /// <exception cref="ValidationException">Invalid Request.</exception>
        public async Task<List<CompanyModuleDetail>> Save(SaveCompanyModuleCommand command)
        {
            if (command.Entity.Any())
            {
                // var items = await this.repository.SaveCompanyModules(command.CompanyId.Value, command.Entity);
                // return this.mapper.Map<List<CompanyModuleDetail>>(items.ToList());
                return null;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List Of CompanyModuleDetail.
        /// </returns>
        public async Task<IList<CompanyModuleDetail>> Search(SearchCompanyModuleCommand command)
        {
            // var items = await this.repository.GetCompanyModules(command.CompanyId.Value);
            // return items;
            return null;
        }
    }
}
