// <copyright file="ICompanyModuleManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Role
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Role.CompanyModule;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Repository.CustomModel;

    /// <summary>
    /// Interface ICompanyModuleManager.
    /// </summary>
    public interface ICompanyModuleManager
    {
        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of CompanyModules.</returns>
        Task<IList<CompanyModuleDetail>> Search(SearchCompanyModuleCommand command);

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List of CompanyModules.
        /// </returns>
        Task<List<CompanyModuleDetail>> Save(SaveCompanyModuleCommand command);
    }
}
