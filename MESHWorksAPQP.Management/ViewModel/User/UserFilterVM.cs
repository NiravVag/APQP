// <copyright file="UserFilterVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.User
{
    using System;

    /// <summary>
    /// Class UserFilterVM.
    /// </summary>
    public class UserFilterVM : FilterVM
    {
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public Guid? RoleId { get; set; }
    }
}
