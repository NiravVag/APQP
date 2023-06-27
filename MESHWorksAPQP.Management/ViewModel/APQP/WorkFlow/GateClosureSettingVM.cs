// <copyright file="GateClosureSettingVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow
{
    using System;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class GateClosureSettingVM.
    /// </summary>
    public class GateClosureSettingVM
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
        public GateClosureApprovalVM GateClosureApproval { get; set; }

        /// <summary>
        /// Gets or sets the gate closure documents.
        /// </summary>
        /// <value>
        /// The gate closure documents.
        /// </value>
        public GateClosureDocumentVM GateClosureDocument { get; set; }

        /// <summary>
        /// Gets or sets the gate closure emails.
        /// </summary>
        /// <value>
        /// The gate closure emails.
        /// </value>
        public GateClosureEmailVM GateClosureEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GateClouserVM"/> is completed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if completed; otherwise, <c>false</c>.
        /// </value>
        public bool Completed { get; set; }
    }
}
