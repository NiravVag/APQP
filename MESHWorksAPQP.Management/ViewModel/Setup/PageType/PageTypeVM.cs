// <copyright file="PageTypeVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Setup
{
    using System;
    using MESHWorksAPQP.Management.Interface.ViewModel;

    /// <summary>
    /// Class PageTypeVM.
    /// </summary>
    public class PageTypeVM : SetupVM, ISaveResult
    {
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets the moduletype identifier.
        /// </summary>
        /// <value>
        /// The moduletype identifier.
        /// </value>
        public Guid ModuleTypeId { get; set; }
    }
}
