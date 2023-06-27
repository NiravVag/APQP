// <copyright file="GateClosureApprovalCM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel.APQP
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class GateClosureApprovalCM.
    /// </summary>
    public class GateClosureApprovalCM
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
        public string ApprovalFor { get; set; }

        /// <summary>
        /// Gets or sets the approved by.
        /// </summary>
        /// <value>
        /// The approved by.
        /// </value>
        public string ApprovedBy { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the type of the approval.
        /// </summary>
        /// <value>
        /// The type of the approval.
        /// </value>
        public ApprovalType ApprovalType { get; set; }

        /// <summary>
        /// Gets or sets the minimum approver.
        /// </summary>
        /// <value>
        /// The minimum approver.
        /// </value>
        public int MinApprover { get; set; }

        /// <summary>
        /// Gets or sets the approver.
        /// </summary>
        /// <value>
        /// The approver.
        /// </value>
        public List<ApproverCM> Approvers { get; set; }
    }
}