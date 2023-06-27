// <copyright file="IEmailNotificationRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces.Setup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.Setup;

    /// <summary>
    /// Interface IEmailNotificationRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.ISetupRepositoty{MESHWorksAPQP.Model.Models.Setup.EmailNotification}" />
    public interface IEmailNotificationRepository : ISetupRepositoty<EmailNotification>
    {
    }
}
