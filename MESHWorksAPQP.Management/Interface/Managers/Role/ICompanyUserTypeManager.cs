// <copyright file="ICompanyUserTypeManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Role
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Role.CompanyUserType;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Company.CompanyUserType;
    using MESHWorksAPQP.Management.ViewModel.User.CompanyUserType;

    /// <summary>
    /// Interface ICompanyUserTypeManager.
    /// </summary>
    public interface ICompanyUserTypeManager
    {
        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Page of CompanyUserTypeListVM.</returns>
        Task<Page<CompanyUserTypeListVM>> Search(SearchCompanyUserTypeCommand command);

        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// CompanyUserTypeVM.
        /// </returns>
        Task<CompanyUserTypeVM> Get(GetCompanyUserTypeCommand command);

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// CompanyUserTypeVM.
        /// </returns>
        Task<CompanyUserTypeVM> Save(SaveCompanyUserTypeCommand command);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// bool.
        /// </returns>
        Task<bool> Delete(DeleteCompanyUserTypeCommand command);
    }
}
