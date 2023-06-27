// <copyright file="ActivityType.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Shared.Enum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Enum ActivityType
    /// </summary>
    public enum ActivityType
    {
        /// <summary>
        /// The launch project
        /// </summary>
        [Description("APQP project launch")]
        APQPProjectLaunch = 1,

        /// <summary>
        /// The closer approver action
        /// </summary>
        [Description("Gate closure approval")]
        GateClosureApproverAction = 2,

        /// <summary>
        /// The apqp template
        /// </summary>
        APQPTemplate = 3,

        /// <summary>
        /// The gates
        /// </summary>
        [Description("Moved to next Gate")]
        MovedToNextGate = 4,

        /// <summary>
        /// The parts
        /// </summary>
        Parts = 5,

        /// <summary>
        /// The custom fields
        /// </summary>
        CustomFields = 6,

        /// <summary>
        /// The created by
        /// </summary>
        CreatedBy = 7,

        /// <summary>
        /// The modified by
        /// </summary>
        ModifiedBy = 8,

        /// <summary>
        /// The deleted by
        /// </summary>
        DeletedBy = 9,

        /// <summary>
        /// The document type
        /// </summary>
        DocumentType = 10,

        /// <summary>
        /// The email closure
        /// </summary>
        [Description("Gate closure email")]
        GateClosureEmail = 11,

        /// <summary>
        /// The gate closure approval request
        /// </summary>
        [Description("Gate closure approval request")]
        GateClosureApprovalRequest = 12,

        /// <summary>
        /// The gate closure closure document
        /// </summary>
        [Description("Gate closure document attached")]
        GateClosureDocument = 13,

        /// <summary>
        /// The reopen gate
        /// </summary>
        ReOpenGate = 14,

        /// <summary>
        /// APQOP Project Completed
        /// </summary>
        [Description("APQOP Project Completed.")]
        APQPProjectCompleted = 15,

        /// <summary>
        /// APQOP Project ReOpened
        /// </summary>
        [Description("APQOP Project ReOpened.")]
        APQPProjectReopened = 16,

        /// <summary>
        /// APQOP Project Deleted
        /// </summary>
        [Description("APQOP Project Deleted.")]
        APQPProjectDeleted = 17
    }
}
