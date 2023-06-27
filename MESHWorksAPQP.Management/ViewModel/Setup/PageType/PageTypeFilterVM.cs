// <copyright file="PageTypeFilterVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Setup.PageType
{
    using System;

    /// <summary>
    /// Class PageTypeFilterVM.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.ViewModel.FilterVM" />
    public class PageTypeFilterVM : FilterVM
    {
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// Gets or sets the moduletype identifier.
        /// </summary>
        /// <value>
        /// The moduletype identifier.
        /// </value>
        public Guid? ModuleTypeId { get; set; }

        /// <summary>
        /// Gets or sets the moduletype identifier.
        /// </summary>
        /// <value>
        /// The pagetype identifier.
        /// </value>
        public Guid? PageTypeId { get; set; }
    }
}
