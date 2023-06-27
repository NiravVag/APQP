// <copyright file="IAPQPDiscussionManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.APQP
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.APQP.APQPDiscussion;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.APQP.Discussion;

    /// <summary>
    /// Interface IAPQPDiscussionManager.
    /// </summary>
    public interface IAPQPDiscussionManager
    {
        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Page of APQPDiscussionListVM.</returns>
        Task<Page<APQPDiscussionListVM>> Search(SearchAPQPDiscussionCommand command);

        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>APQPDiscussionVM.</returns>
        Task<APQPDiscussionVM> Get(GetAPQPDiscussionCommand command);

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>APQPDiscussionVM</returns>
        Task<APQPDiscussionVM> Save(SaveAPQPDiscussionCommand command);

        /// <summary>
        /// Deletes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>bool.</returns>
        Task<bool> Delete(DeleteAPQPDiscussionCommand command);
    }
}
