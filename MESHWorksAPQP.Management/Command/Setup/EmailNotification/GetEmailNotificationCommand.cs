﻿// <copyright file="GetEmailNotificationCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.Setup.EmailNotification
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification;

    /// <summary>
    ///  Class GetCommodityCommand.
    /// </summary>
    public class GetEmailNotificationCommand : IGetCommand<EmailNotificationVM>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public EmailNotificationVM Result { get; set; }
    }
}
