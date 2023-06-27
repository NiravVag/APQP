// <copyright file="UploadAttachmentVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Document
{
    using System;
    using MESHWorksAPQP.Shared.Enum;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Class UploadAttachmentVM.
    /// </summary>
    public class UploadAttachmentVM
    {
        /// <summary>
        /// Gets or sets the apqp identifier.
        /// </summary>
        /// <value>
        /// The apqp identifier.
        /// </value>
        public Guid? APQPId { get; set; }

        /// <summary>
        /// Gets or sets the folder identifier.
        /// </summary>
        /// <value>
        /// The folder identifier.
        /// </value>
        public Guid? EntityId { get; set; }

        /// <summary>
        /// Gets or sets the referance identifier.
        /// </summary>
        /// <value>
        /// The folder identifier.
        /// </value>
        public Guid? ReferanceId { get; set; }

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        public IFormFile File { get; set; }

        /// <summary>
        /// Gets or sets the type of the attachment.
        /// </summary>
        /// <value>
        /// The type of the attachment.
        /// </value>
        public DocumenType AttachmentType { get; set; }

        /// <summary>
        /// Gets or sets the documen type identifier.
        /// </summary>
        /// <value>
        /// The documen type identifier.
        /// </value>
        public Guid DocumenTypeId { get; set; }
    }
}
