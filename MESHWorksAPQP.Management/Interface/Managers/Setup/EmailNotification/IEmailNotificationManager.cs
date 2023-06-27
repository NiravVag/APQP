// <copyright file="IEmailNotificationManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Setup.EmailNotification
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.EmailNotification;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification;

    /// <summary>
    /// Interface IEmailNotificationManager.
    /// </summary>
    public interface IEmailNotificationManager
    {
        /// <summary>
        /// Gets the specified get part command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>PartVM.</returns>
        Task<EmailNotificationVM> Get(GetEmailNotificationCommand command);

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
        Task<EmailNotificationVM> Save(SaveEmailNotificationCommand command);

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of PartListVM.</returns>
        Task<Page<EmailNotificationListVM>> Search(SearchEmailNotificationCommand command);
    }
}
