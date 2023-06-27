// <copyright file="ApprovalType.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Shared.Enum
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// enum ApprovalType.
    /// </summary>
    public enum ApprovalType
    {
        /// <summary>
        /// The BasicFlow
        /// </summary>
        [Display(Name = "Basic")]
        Basic = 1,

        /// <summary>
        /// The AdvanceFlow
        /// </summary>
        [Display(Name = "Advance")]
        Advance = 2,

        /// <summary>
        /// The ChainFlow
        /// </summary>
        [Display(Name = "Chain")]
        Chain = 3,
    }
}
