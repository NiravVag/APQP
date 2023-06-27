// <copyright file="IPageTypeManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Setup.PageType
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.PageType;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;

    /// <summary>
    /// Interface IPageTypeManager.
    /// </summary>
    public interface IPageTypeManager
    {
        /// <summary>
        /// Gets the specified get process command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>SetupVM.</returns>
        Task<SetupVM> Get(GetPageTypeCommand command);

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
        Task<PageTypeVM> Save(SavePageTypeCommand command);

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of SetupListVM.</returns>
        Task<Page<SetupListVM>> Search(SearchPageTypeCommand command);
    }
}
