// <copyright file="ICommodityManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>
namespace MESHWorksAPQP.Management.Interface.Managers.Setup.Commodity
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Commodity;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;

    /// <summary>
    /// Interface ICommodityManager.
    /// </summary>
    public interface ICommodityManager
    {
        /// <summary>
        /// Gets the specified get part command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>PartVM.</returns>
        Task<SetupVM> Get(GetCommodityCommand command);

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
        /// <returns>PartVM.</returns>
        Task<SetupVM> Save(SaveCommodityCommand command);

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of PartListVM.</returns>
        Task<Page<SetupListVM>> Search(SearchCommodityCommand command);
    }
}
