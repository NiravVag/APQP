// <copyright file="GateClosureDocumentCM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel.APQP
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// GateClosureDocumentCM.
    /// </summary>
    public class GateClosureDocumentCM
    {
        /// <summary>
        /// Gets or sets the gate closure setting identifier.
        /// </summary>
        /// <value>
        /// The gate closure setting identifier.
        /// </value>
        public Guid GateClosureSettingId { get; set; }

        /// <summary>
        /// Gets or sets the document attachments.
        /// </summary>
        /// <value>
        /// The document attachments.
        /// </value>
        public List<DocumentAttachmentCM> DocumentAttachments { get; set; }

        /// <summary>
        /// Gets or sets the document types.
        /// </summary>
        /// <value>
        /// The document types.
        /// </value>
        public List<Guid> DocumentTypes { get; set; }

        /// <summary>
        /// Gets or sets the name of the document type.
        /// </summary>
        /// <value>
        /// The name of the document type.
        /// </value>
        public string DocumentTypeNames { get; set; }
    }
}
