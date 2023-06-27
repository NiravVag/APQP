// <copyright file="PagingOptions.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class PagingOptions.
    /// </summary>
    public class PagingOptions
    {
        /// <summary>
        /// The maximum page size.
        /// </summary>
        public const int MaxPageSize = 100;

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        [Range(0, int.MaxValue, ErrorMessage = "Offset must be greater than 0.")]
        public int? Offset { get; set; }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        [Range(1, MaxPageSize, ErrorMessage = "Limit must be greater than 0 and less than 100.")]
        public int? Limit { get; set; }
    }
}
