// <copyright file="ActivityFilterVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Activity
{
    using System;

    /// <summary>
    /// Class ActivityFilterVM
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.ViewModel.FilterVM" />
    public class ActivityFilterVM : FilterVM
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public Guid EntityId { get; set; }

        /// <summary>
        /// Gets or sets the referance identifier.
        /// </summary>
        /// <value>
        /// The referance identifier.
        /// </value>
        public Guid? ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the child entity identifier.
        /// </summary>
        /// <value>
        /// The child entity identifier.
        /// </value>
        public Guid? ChildEntityId { get; set; }
    }
}
