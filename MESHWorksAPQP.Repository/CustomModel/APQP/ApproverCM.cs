// <copyright file="ApproverCM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel.APQP
{
    using System;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class ApproverCM.
    /// </summary>
    public class ApproverCM
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the gate closure approval identifier.
        /// </summary>
        /// <value>
        /// The gate closure approval identifier.
        /// </value>
        public Guid GateClosureApprovalId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [required approver].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [required approver]; otherwise, <c>false</c>.
        /// </value>
        public bool RequiredApprover { get; set; }

        /// <summary>
        /// Gets or sets the chain order.
        /// </summary>
        /// <value>
        /// The chain order.
        /// </value>
        public int ChainOrder { get; set; }

        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public ApprovalStatus ApprovalStatus { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }
    }
}