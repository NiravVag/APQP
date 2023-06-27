// <copyright file="Approver.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.APQP.WorkFlow
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;

    /// <summary>
    /// class Approver.
    /// </summary>
    [Table("Approver", Schema = "APQP")]
    public class Approver : BaseEntity
    {
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
    }
}
