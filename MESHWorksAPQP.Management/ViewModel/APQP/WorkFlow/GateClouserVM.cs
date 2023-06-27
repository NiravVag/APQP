// <copyright file="GateClouserVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow
{
    using System;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class GateClouserVM.
    /// </summary>
    public class GateClouserVM
    {
        /// <summary>
        /// Gets or sets the gate closure identifier.
        /// </summary>
        /// <value>
        /// The gate closure identifier.
        /// </value>
        public Guid GateClosureSettingId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GateClouserVM"/> is completed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if completed; otherwise, <c>false</c>.
        /// </value>
        public bool Completed { get; set; }

        public bool ApprovalInProgess { get; set; }
    }
}
