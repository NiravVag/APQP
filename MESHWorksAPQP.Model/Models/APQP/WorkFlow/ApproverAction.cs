// <copyright file="ApproverAction.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.APQP.WorkFlow
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class ApproverAction.
    /// </summary>
    [Table("ApproverAction", Schema = "APQP")]
    public class ApproverAction : BaseEntity
    {
        /// <summary>
        /// Gets or sets the gate closure approval identifier.
        /// </summary>
        /// <value>
        /// The gate closure approval identifier.
        /// </value>
        public Guid GateClosureApprovalId { get; set; }

        /// <summary>
        /// Gets or sets the closure reference identifier.
        /// </summary>
        /// <value>
        /// The closure reference identifier.
        /// </value>
        public Guid ClosureReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

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
