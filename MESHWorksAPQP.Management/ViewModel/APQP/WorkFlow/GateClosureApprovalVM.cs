// <copyright file="GateClosureApprovalVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class GateClosureApprovalVM.
    /// </summary>
    public class GateClosureApprovalVM
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the gate closure setting identifier.
        /// </summary>
        /// <value>
        /// The gate closure setting identifier.
        /// </value>
        public Guid GateClosureSettingId { get; set; }

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
        public List<ApproverVM> Approvers { get; set; }
    }
}