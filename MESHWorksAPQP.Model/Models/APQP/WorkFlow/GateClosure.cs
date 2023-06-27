// <copyright file="GateClosure.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.APQP.WorkFlow
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class GateClosure.
    /// </summary>
    [Table("GateClosure", Schema = "APQP")]
    public class GateClosure : BaseEntity
    {
        /// <summary>
        /// Gets or sets the gate closure setting identifier.
        /// </summary>
        /// <value>
        /// The gate closure setting identifier.
        /// </value>
        public Guid GateClosureSettingId { get; set; }

        /// <summary>
        /// Gets or sets the gate closure setting.
        /// </summary>
        /// <value>
        /// The gate closure setting.
        /// </value>
        public virtual GateClosureSetting GateClosureSetting { get; set; }

        /// <summary>
        /// Gets or sets the type of the clouser.
        /// </summary>
        /// <value>
        /// The type of the clouser.
        /// </value>
        public ClouserType ClouserType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is completed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is completed; otherwise, <c>false</c>.
        /// </value>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Gets or sets the closure reference identifier.
        /// </summary>
        /// <value>
        /// The closure reference identifier.
        /// </value>
        public Guid ClosureReferenceId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [approval in progress].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [approval in progress]; otherwise, <c>false</c>.
        /// </value>
        public bool ApprovalInProgress { get; set; }
    }
}
