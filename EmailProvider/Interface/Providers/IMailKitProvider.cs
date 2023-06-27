// <copyright file="IMailKitProvider.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace EmailProvider.Interface.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using MimeKit;
    using MESHWorksAPQP.Model.Models.Email;

    /// <summary>
    /// Interface IMailKitProvider.
    /// </summary>
    public interface IMailKitProvider
    {
        /// <summary>
        /// Sends the specified from.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="emailConfiguration">The emailConfiguration.</param>
        /// <returns>Task.</returns>
        Task Send(MimeMessage message, EmailConfiguration emailConfiguration);
    }
}
