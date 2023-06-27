// <copyright file="ApproverVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow
{
    using System;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    ///  class ApproverVM.
    /// </summary>
    public class APQPVM
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the gate identifier.
        /// </summary>
        /// <value>
        /// The gate identifier.
        /// </value>
        public Guid GateID { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public APQPStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the activity.
        /// </summary>
        /// <value>
        /// The activity.
        /// </value>
        public ActivityType Activity { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }       
    }
}