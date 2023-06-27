// <copyright file="DocumenType.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Shared.Enum
{
    using System.ComponentModel;

    /// <summary>
    /// Enum DocumenType.
    /// </summary>
    public enum DocumenType
    {
        /// <summary>
        /// The company logo
        /// </summary>
        [Description("CompanyLogo")]
        CompanyLogo = 1,

        /// <summary>
        /// The company
        /// </summary>
        [Description("Company")]
        Company = 2,

        /// <summary>
        /// The part
        /// </summary>
        [Description("Part")]
        Part = 3,

        /// <summary>
        /// The discussion
        /// </summary>
        [Description("Discussion")]
        Discussion = 4,

        /// <summary>
        /// The Closure
        /// </summary>
        [Description("Closure")]
        Closure = 5,

        /// <summary>
        /// The Gate
        /// </summary>
        [Description("Gate")]
        Gate = 6
    }
}
