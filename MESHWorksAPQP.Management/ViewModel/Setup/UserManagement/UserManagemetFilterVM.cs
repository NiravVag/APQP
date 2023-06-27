// <copyright file="UserManagemetFilterVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Setup.UserManagement
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class UserManagemetFilterVM.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.ViewModel.FilterVM" />
    public class UserManagemetFilterVM : FilterVM
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// Gets or sets the designation ids.
        /// </summary>
        /// <value>
        /// The designation ids.
        /// </value>
        public List<Guid> designationId { get; set; }
    }
}
