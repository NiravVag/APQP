// <copyright file="PartFilterVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Part
{
    using System;

    /// <summary>
    /// class PartFilterVM.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.ViewModel.FilterVM" />
    public class PartFilterVM : FilterVM
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the part identifier.
        /// </summary>
        /// <value>
        /// The part identifier.
        /// </value>
        public Guid PartId { get; set; }

        /// <summary>
        /// Gets or sets the part number.
        /// </summary>
        /// <value>
        /// The part number.
        /// </value>
        public string PartNumber { get; set; }
    }
}
