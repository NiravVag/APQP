// <copyright file="DocumentAttachmentCM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel.APQP
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// class DocumentAttachmentCM.
    /// </summary>
    public class DocumentAttachmentCM
    {
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
        public string DocumentTypeName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is completed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is completed; otherwise, <c>false</c>.
        /// </value>
        public bool IsAttached { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the attachment.
        /// </summary>
        /// <value>
        /// The attachment.
        /// </value>
        public List<AttachmentDetailVM> Attachments { get; set; }
    }
}