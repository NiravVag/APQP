// <copyright file="IRoleManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Setup.Role
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Role;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;

    /// <summary>
    /// Interface IRoleManager.
    /// </summary>
    public interface IRoleManager
    {
        /// <summary>
        /// Gets the specified get process command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>SetupVM.</returns>
        Task<SetupVM> Get(GetRoleCommand command);

        /// <summary>
        /// Deletes the specified command.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// bool.
        /// </returns>
        Task<bool> Delete(Guid id);

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>SetupVM.</returns>
        Task<SetupVM> Save(SaveRoleCommand command);

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of SetupListVM.</returns>
        Task<Page<SetupListVM>> Search(SearchRoleCommand command);
    }
}
