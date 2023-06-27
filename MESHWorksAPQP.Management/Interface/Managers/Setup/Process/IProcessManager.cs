// <copyright file="IProcessManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Setup.Process
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Process;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Management.ViewModel.Setup.Process;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// Interface IProcessManager.
    /// </summary>
    public interface IProcessManager
    {
        /// <summary>
        /// Gets the specified get process command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>SetupVM.</returns>
        Task<SetupVM> Get(GetProcessCommand command);

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
        Task<SetupVM> Save(SaveProcessCommand command);

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of ProcessListVM.</returns>
        Task<Page<SetupListVM>> Search(SearchProcessCommand command);
    }
}
