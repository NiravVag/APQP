// <copyright file="EmailStatus.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Shared.Enum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Enum EmailStatus.
    /// </summary>
    public enum EmailStatus
    {
        /// <summary>
        /// The draft
        /// </summary>
        Draft = 1,

        /// <summary>
        /// The in process
        /// </summary>
        InProcess = 2,

        /// <summary>
        /// The sent
        /// </summary>
        Sent = 3,

        /// <summary>
        /// The failed
        /// </summary>
        Failed = 4
    }
}
