// <copyright file="IUserManagementManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Setup.UserManagement
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.UserManagement;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup.UserManagement;

    /// <summary>
    /// Interface IUserManagementManager.
    /// </summary>
    public interface IUserManagementManager
    {
        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>UserManagementVM.</returns>
        Task<UserManagementVM> Get(GetUserManagementCommand command);

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>UserManagementVM.</returns>
        Task<UserManagementVM> Save(SaveUserManagementCommand command);

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of UserManagementListVM.</returns>
        Task<Page<UserManagementListVM>> Search(SearchUserManagementCommand command);
    }
}
