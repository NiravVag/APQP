// <copyright file="ApprovalStatus.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Shared.Enum
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// enum ApprovalStatus.
    /// </summary>
    public enum ApprovalStatus
    {
        /// <summary>
        /// The Pending
        /// </summary>
        [Display(Name = "Pending")]
        Pending = 1,

        /// <summary>
        /// The Approved
        /// </summary>
        [Display(Name = "Approved")]
        Approved = 2,

        /// <summary>
        /// The Rejected
        /// </summary>
        [Display(Name = "Rejected")]
        Rejected = 3,

        /// <summary>
        /// The Query
        /// </summary>
        [Display(Name = "Query")]
        Query = 4,
    }
}
