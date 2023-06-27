// <copyright file="GateClosureApproval.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.APQP.WorkFlow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class GateClosureApproval.
    /// </summary>
    [Table("GateClosureApproval", Schema = "APQP")]
    public class GateClosureApproval : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GateClosureApproval"/> class.
        /// </summary>
        public GateClosureApproval()
        {
            this.Approvers = new HashSet<Approver>();
        }

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
        /// Gets or sets the approval for.
        /// </summary>
        /// <value>
        /// The approval for.
        /// </value>
        [MaxLength(100)]
        public string ApprovalFor { get; set; }

        /// <summary>
        /// Gets or sets the approved by.
        /// </summary>
        /// <value>
        /// The approved by.
        /// </value>
        [MaxLength(50)]
        public string ApprovedBy { get; set; }

        /// <summary>
        /// Gets or sets my property.
        /// </summary>
        /// <value>
        /// My property.
        /// </value>
        public ApprovalType ApprovalType { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the minimum approver.
        /// </summary>
        /// <value>
        /// The minimum approver.
        /// </value>
        public int MinApprover { get; set; }

        /// <summary>
        /// Gets or sets the approvers.
        /// </summary>
        /// <value>
        /// The approvers.
        /// </value>
        public virtual ICollection<Approver> Approvers { get; set; }
    }
}
