// <copyright file="IDocumentAttachmentManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Document
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmailProvider.ViewModels;
    using MESHWorksAPQP.Management.Commands.Document;
    using MESHWorksAPQP.Management.ViewModel.Document;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Shared.Enum;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// Interface IDocumentAttachmentManager.
    /// </summary>
    public interface IDocumentAttachmentManager
    {
        /// <summary>
        /// Uploads the attachments.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// Task.
        /// </returns>
        Task<AttachmentDetailVM> UploadAttachment(UploadAttachmentCommand command);

        /// <summary>
        /// Deletes the specified documen type.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        Task<bool> Delete(Guid id);

        /// <summary>
        /// Gets the attachments.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="documenTypeId">The documenTypeId.</param>
        /// <param name="referanceId">The referanceID.</param>
        /// <returns>
        /// List of AttachmentDetailVM.
        /// </returns>
        Task<List<AttachmentDetailVM>> GetAttachments(Guid entityId, Guid? documenTypeId = null, Guid? referanceId = null);

        /// <summary>
        /// Downloads the attachment.
        /// </summary>
        /// <param name="documenType">Type of the document attachment.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// DownloadAttachmentVM.
        /// </returns>
        Task<DownloadAttachmentVM> DownloadAttachment(DocumenType documenType, Guid id);

        /// <summary>
        /// Sets the attachment entity.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="attachments">The attachments.</param>
        /// <returns>List of AttachmentDetailVM.</returns>
        Task<List<AttachmentDetailVM>> SetAttachmentEntity(Guid entityId, List<AttachmentDetailVM> attachments);

        /// <summary>
        /// Clones the document.
        /// </summary>
        /// <param name="attachment">The attachment.</param>
        /// <returns>AttachmentDetailVM.</returns>
        Task<AttachmentDetailVM> CloneDocument(AttachmentDetailVM attachment);

        /// <summary>
        /// Gets the document attachments.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="documenType">Type of the document attachment.</param>
        /// <returns>List of EmailAttachmentVM.</returns>
        Task<List<EmailAttachmentVM>> GetEmailAttachments(Guid entityId, DocumenType? documenType = null);
    }
}
