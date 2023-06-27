// <copyright file="Page{T}.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel
{
    using System.Collections.Generic;

    /// <summary>
    /// Class Page.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class Page<T>
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the total size.
        /// </summary>
        /// <value>
        /// The total size.
        /// </value>
        public int TotalSize { get; set; }
    }
}
