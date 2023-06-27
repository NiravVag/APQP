// <copyright file="IMaterialTypeManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Setup.MaterialType
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.MaterialType;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;

    /// <summary>
    /// Interface IMaterialTypeManager.
    /// </summary>
    public interface IMaterialTypeManager
    {
        /// <summary>
        /// Gets the specified get process command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>SetupVM.</returns>
        Task<MaterialVM> Get(GetMaterialTypeCommand command);

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
        Task<MaterialVM> Save(SaveMaterialTypeCommand command);

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of SetupListVM.</returns>
        Task<Page<SetupListVM>> Search(SearchMaterialTypeCommand command);
    }
}
