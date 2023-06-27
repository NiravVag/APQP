// <copyright file="GroupedLookupVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Lookup
{
    using System.Collections.Generic;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// Class GroupedLookupVM.
    /// </summary>
    public class GroupedLookupVM
    {
        /// <summary>
        /// Gets or sets the group by.
        /// </summary>
        /// <value>
        /// The group by.
        /// </value>
        public string GroupBy { get; set; }

        /// <summary>
        /// Gets or sets the group items.
        /// </summary>
        /// <value>
        /// The group items.
        /// </value>
        public List<LookupVM> GroupItems { get; set; }
    }
}
