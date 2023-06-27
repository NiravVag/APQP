// <copyright file="GateClosureSettingCM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel.APQP
{
    using System;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class GateClosureSettingCM.
    /// </summary>
    public class GateClosureSettingCM
    {
        /// <summary>
        /// Gets or sets the gate identifier.
        /// </summary>
        /// <value>
        /// The gate identifier.
        /// </value>
        public Guid? GateId { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the clouser.
        /// </summary>
        /// <value>
        /// The type of the clouser.
        /// </value>
        public ClouserType ClouserType { get; set; }

        /// <summary>
        /// Gets or sets the name of the closure type.
        /// </summary>
        /// <value>
        /// The name of the closure type.
        /// </value>
        public string ClosureTypeName { get; set; }

        /// <summary>
        /// Gets or sets the gate closure approvals.
        /// </summary>
        /// <value>
        /// The gate closure approvals.
        /// </value>
        public GateClosureApprovalCM GateClosureApproval { get; set; }

        /// <summary>
        /// Gets or sets the gate closure documents.
        /// </summary>
        /// <value>
        /// The gate closure documents.
        /// </value>
        public GateClosureDocumentCM GateClosureDocument { get; set; }

        /// <summary>
        /// Gets or sets the gate closure emails.
        /// </summary>
        /// <value>
        /// The gate closure emails.
        /// </value>
        public GateClosureEmailCM GateClosureEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GateClosureSettingVM"/> is completed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if completed; otherwise, <c>false</c>.
        /// </value>
        public bool Completed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [approval in progress].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [approval in progress]; otherwise, <c>false</c>.
        /// </value>
        public bool ApprovalInProgress { get; set; }
    }
}