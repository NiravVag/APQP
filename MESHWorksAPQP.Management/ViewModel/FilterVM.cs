// <copyright file="FilterVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel
{
    using MESHWorksAPQP.Management.Interface.ViewModel;

    /// <summary>
    /// Class FilterVM.
    /// </summary>
    public class FilterVM : IFilterVM
    {
        /// <summary>
        /// Gets or sets the search text.
        /// </summary>
        /// <value>
        /// The search text.
        /// </value>
        public string SearchText { get; set; }

        /// <summary>
        /// Gets or sets the is deleted.
        /// </summary>
        /// <value>
        /// The is deleted.
        /// </value>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the paging option.
        /// </summary>
        /// <value>
        /// The paging option.
        /// </value>
        public PagingOptions PagingOption { get; set; }

        /// <summary>
        /// Gets or sets the sorting option.
        /// </summary>
        /// <value>
        /// The sorting option.
        /// </value>
        public SortingOptions SortingOption { get; set; }
    }
}
