// <copyright file="GateClosureCM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel.APQP
{
    using System;

    /// <summary>
    /// class GateClosureCM
    /// </summary>
    public class GateClosureCM
    {
        /// <summary>
        /// Gets or sets the gate closure identifier.
        /// </summary>
        /// <value>
        /// The gate closure identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the gate identifier.
        /// </summary>
        /// <value>
        /// The gate identifier.
        /// </value>
        public Guid GateId { get; set; }

        /// <summary>
        /// Gets or sets the closure reference identifier.
        /// </summary>
        /// <value>
        /// The closure reference identifier.
        /// </value>
        public Guid ClosureReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the gate closure setting identifier.
        /// </summary>
        /// <value>
        /// The gate closure setting identifier.
        /// </value>
        public Guid GateClosureSettingId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is completed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is completed; otherwise, <c>false</c>.
        /// </value>
        public bool IsCompleted { get; set; }
    }
}