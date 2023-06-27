// <copyright file="ClouserType.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Shared.Enum
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// enum ClouserType.
    /// </summary>
    public enum ClouserType
    {
        /// <summary>
        /// The Email
        /// </summary>
        [Display(Name = "Email")]
        Email = 1,

        /// <summary>
        /// The Document
        /// </summary>
        [Display(Name = "Document")]
        Document = 2,

        /// <summary>
        /// The Approval
        /// </summary>
        [Display(Name = "Approval")]
        Approval = 3,
    }
}
