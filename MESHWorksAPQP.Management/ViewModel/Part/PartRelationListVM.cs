// <copyright file="PartRelationListVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Part
{
    using System;

    /// <summary>
    /// class PartRelationListVM.
    /// </summary>
    public class PartRelationListVM : PartListVM
    {
        /// <summary>
        /// Gets or sets the parent part identifier.
        /// </summary>
        /// <value>
        /// The parent part identifier.
        /// </value>
        public Guid ParentPartId { get; set; }
    }
}
