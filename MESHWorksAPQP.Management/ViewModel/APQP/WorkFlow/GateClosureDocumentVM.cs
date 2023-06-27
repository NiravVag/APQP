// <copyright file="GateClosureDocumentVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Repository.CustomModel.APQP;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// class GateClosureDocumentVM.
    /// </summary>
    public class GateClosureDocumentVM
    {
        /// <summary>
        /// Gets or sets the gate closure setting identifier.
        /// </summary>
        /// <value>
        /// The gate closure setting identifier.
        /// </value>
        public Guid GateClosureSettingId { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the document type identifier.
        /// </summary>
        /// <value>
        /// The document type identifier.
        /// </value>
        public Guid DocumentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the document type.
        /// </summary>
        /// <value>
        /// The name of the document type.
        /// </value>
        public string DocumentTypeNames { get; set; }

        /// <summary>
        /// Gets or sets the document types.
        /// </summary>
        /// <value>
        /// The document types.
        /// </value>
        public List<Guid> DocumentTypes { get; set; }

        /// <summary>
        /// Gets or sets the document attachments.
        /// </summary>
        /// <value>
        /// The document attachments.
        /// </value>
        public List<AttachmentDetailVM> DocumentAttachments { get; set; }
    }
}
