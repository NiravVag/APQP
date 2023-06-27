// <copyright file="UploadAttachmentHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Document
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Document;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Document;

    /// <summary>
    /// Class UploadAttachmentHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Document.UploadAttachmentCommand}" />
    public class UploadAttachmentHandler : ICommandHandler<UploadAttachmentCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IDocumentAttachmentManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadAttachmentHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="companyManager">The company manager.</param>
        public UploadAttachmentHandler(IDocumentAttachmentManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(UploadAttachmentCommand command)
        {
            command.Result = await this.manager.UploadAttachment(command);
        }
    }
}