// <copyright file="EmailNotificationListVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification
{
    using System;

    /// <summary>
    /// Class EmailNotificationListVM.
    /// </summary>
    public class EmailNotificationListVM : SetupListVM
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }
    }
}
