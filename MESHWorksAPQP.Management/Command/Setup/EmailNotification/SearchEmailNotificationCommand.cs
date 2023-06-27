// <copyright file="SearchEmailNotificationCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.Setup.EmailNotification
{
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification;

    /// <summary>
    /// class SearchEmailNotificationCommand.
    /// </summary>
    public class SearchEmailNotificationCommand : Page<EmailNotificationListVM>, ISearchCommand<EmailNotificationListVM, EmailNotificationFilterVM>
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public EmailNotificationFilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Page<EmailNotificationListVM> Result { get; set; }
    }
}
