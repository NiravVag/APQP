// <copyright file="EmailNotificationVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification
{
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class EmailNotificationVM.
    /// </summary>
    public class EmailNotificationVM : SetupVM
    {
        /// <summary>
        /// Gets or sets the CompanyType.
        /// </summary>
        public CompanyType CompanyType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is owner option available.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is owner option available; otherwise, <c>false</c>.
        /// </value>
        public bool IsOwnerOptionAvailable { get; set; }
    }
}
