// <copyright file="EmailNotificationFilterVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification
{
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class EmailNotificationFilterVM.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.ViewModel.FilterVM" />
    public class EmailNotificationFilterVM : FilterVM
    {
        /// <summary>
        /// Gets or sets the CompanyType identifier.
        /// </summary>
        /// <value>
        /// The CompanyType identifier.
        /// </value>
        public CompanyType CompanyType { get; set; }

        /// <summary>
        /// Gets or sets the part number.
        /// </summary>
        /// <value>
        /// The Code.
        /// </value>
        public string Code { get; set; }
    }
}
