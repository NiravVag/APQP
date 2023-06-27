// <copyright file="IFilterVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.ViewModel;

    /// <summary>
    /// Interface IFilterVM.
    /// </summary>
    public interface IFilterVM
    {
        /// <summary>
        /// Gets or sets the search text.
        /// </summary>
        /// <value>
        /// The search text.
        /// </value>
        string SearchText { get; set; }

        /// <summary>
        /// Gets or sets the is deleted.
        /// </summary>
        /// <value>
        /// The is deleted.
        /// </value>
        bool? IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the paging option.
        /// </summary>
        /// <value>
        /// The paging option.
        /// </value>
        PagingOptions PagingOption { get; set; }

        /// <summary>
        /// Gets or sets the sorting option.
        /// </summary>
        /// <value>
        /// The sorting option.
        /// </value>
        SortingOptions SortingOption { get; set; }
    }
}
