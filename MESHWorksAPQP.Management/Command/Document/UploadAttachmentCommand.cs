// <copyright file="UploadAttachmentCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.Document
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Abstract;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.Document;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// Class UploadAttachmentCommand.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Commands.Abstract.BaseAPQPCommand{MESHWorksAPQP.Management.ViewModel.Document.UploadAttachmentVM}" />
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.ISaveCommand{MESHWorksAPQP.Management.ViewModel.Document.UploadAttachmentVM}" />
    public class UploadAttachmentCommand : BaseAPQPCommand<AttachmentDetailVM>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public UploadAttachmentVM Entity { get; set; }
    }
}