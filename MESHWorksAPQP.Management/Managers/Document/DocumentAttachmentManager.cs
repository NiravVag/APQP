// <copyright file="DocumentAttachmentManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Document
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EmailProvider.ViewModels;
    using MESHWorksAPQP.Management.Commands.Document;
    using MESHWorksAPQP.Management.Helpers;
    using MESHWorksAPQP.Management.Interface.Managers.Activity;
    using MESHWorksAPQP.Management.Interface.Managers.Document;
    using MESHWorksAPQP.Management.ViewModel.Activity;
    using MESHWorksAPQP.Management.ViewModel.Document;
    using MESHWorksAPQP.Model.Models.Documents;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Shared.Enum;
    using MESHWorksAPQP.Shared.Models;
    using StorageManager.Interface;

    /// <summary>
    /// Class DocumentAttachmentManager.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Managers.Document.IDocumentManager" />
    public class DocumentAttachmentManager : IDocumentAttachmentManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IGenericRepository<Document> repository;

        /// <summary>
        /// The document type repository
        /// </summary>
        private readonly ISetupRepositoty<DocumentType> documentTypeRepository;

        /// <summary>
        /// The document storage manager.
        /// </summary>
        private readonly IDocumentStorageManager documentStorageManager;

        /// <summary>
        /// The activity manager
        /// </summary>
        private readonly IActivityManager activityManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAttachmentManager" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="documentStorageManager">The document storage manager.</param>
        /// <param name="documentTypeRepository">The document type repository.</param>
        /// <param name="activityManager">The activityManager.</param>
        public DocumentAttachmentManager(
           IMapper mapper,
           IGenericRepository<Document> repository,
           IDocumentStorageManager documentStorageManager,
           ISetupRepositoty<DocumentType> documentTypeRepository,
           IActivityManager activityManager)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.documentStorageManager = documentStorageManager;
            this.documentTypeRepository = documentTypeRepository;
            this.activityManager = activityManager;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Task.
        /// </returns>
        public async Task<bool> Delete(Guid id)
        {
            var entity = await this.repository.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (entity == null)
            {
                throw new ValidationException("Attachment not found.");
            }

            await this.documentStorageManager.RemoveDocument(entity.FilePath);
            entity.IsDeleted = true;
            this.repository.Update(entity);

            await this.repository.SaveAsync();
            return true;
        }

        /// <summary>
        /// Downloads the attachment.
        /// </summary>
        /// <param name="documenType">Type of the document attachment.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// DownloadAttachmentVM.
        /// </returns>
        public async Task<DownloadAttachmentVM> DownloadAttachment(DocumenType documenType, Guid id)
        {
            var entity = await this.repository.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (entity == null)
            {
                throw new ValidationException("Attachment not found.");
            }

            var downloadAttachmentVM = new DownloadAttachmentVM();
            downloadAttachmentVM.FileName = entity.FileName;
            downloadAttachmentVM.ContentType = entity.ContentType;
            downloadAttachmentVM.FileContent = await this.documentStorageManager.GetDocumentBytes(entity.FilePath);

            return downloadAttachmentVM;
        }

        /// <summary>
        /// Gets the attachments.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="documenTypeId">The documenTypeId</param>
        /// <param name="referenceId">The referenceId</param>
        /// <returns>
        /// List of AttachmentDetailVM.
        /// </returns>
        public Task<List<AttachmentDetailVM>> GetAttachments(Guid entityId, Guid? documenTypeId = null, Guid? referenceId = null)
        {
            var query = this.repository.GetAll(x => x.EntityId == entityId && x.IsDeleted == false);
            if (documenTypeId.HasValue)
            {
                query = query.Where(x => x.DocumentTypeId == documenTypeId);
            }

            if (referenceId.HasValue)
            {
                query = query.Where(x => x.ReferanceId == referenceId);
            }

            return Task.FromResult(query.ProjectTo<AttachmentDetailVM>(this.mapper.ConfigurationProvider).ToList());
        }

        /// <summary>
        /// Gets the document attachments.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="DocumenType">Type of the document attachment.</param>
        /// <returns>
        /// List of EmailAttachmentVM.
        /// </returns>
        public Task<List<EmailAttachmentVM>> GetEmailAttachments(Guid entityId, DocumenType? DocumenType = null)
        {
            var query = this.repository.GetAll(x => x.EntityId == entityId && x.IsDeleted == false);

            // if (DocumenType != null)
            // {
            //     query = query.Where(x => x.DocumenType == DocumenType);
            // }
            return Task.FromResult(query.ProjectTo<EmailAttachmentVM>(this.mapper.ConfigurationProvider).ToList());
        }

        /// <summary>
        /// Uploads the attachments.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// Task.
        /// </returns>
        public async Task<AttachmentDetailVM> UploadAttachment(UploadAttachmentCommand command)
        {
            Document entity = null;

            if (command.Entity.AttachmentType == DocumenType.CompanyLogo)
            {
                entity = await this.repository.FirstOrDefaultAsync(x => x.Id == command.CompanyId && x.EntityId == command.CompanyId && x.IsDeleted == false);

                if (entity != null)
                {
                    entity.FileName = command.Entity.File.FileName;
                    entity.ContentType = command.Entity.File.ContentType;
                    entity.FileSize = command.Entity.File.Length;

                    this.repository.Update(entity);
                }
            }

            if (entity == null)
            {
                entity = new Document();
                entity.Id = Guid.NewGuid();
                entity.FileName = command.Entity.File.FileName;
                entity.ContentType = command.Entity.File.ContentType;
                entity.FileSize = command.Entity.File.Length;
                entity.DocumentTypeId = command.Entity.DocumenTypeId;
                entity.EntityId = command.Entity.EntityId;
                entity.ReferanceId = command.Entity.ReferanceId;
                this.repository.Create(entity);
            }

            string blobFilePath = $"APQP";

            switch (command.Entity.AttachmentType)
            {
                case DocumenType.Discussion:
                    var documentTypeEntity = await this.documentTypeRepository.FirstOrDefaultAsync(x => x.Code == DocumenType.Discussion.DescriptionAttribute() && !x.IsDeleted);
                    entity.DocumentTypeId = documentTypeEntity.Id;
                    blobFilePath = $"APQP/{command.Entity.APQPId.Value}/Discussion";
                    break;
                case DocumenType.Closure:
                    blobFilePath = $"APQP/{command.Entity.APQPId.Value}/Closure";
                    break;
                case DocumenType.Gate:
                    blobFilePath = $"APQP/{command.Entity.APQPId.Value}/Gate";
                    break;
            }

            string fullName = $"{blobFilePath}/{entity.Id}{Path.GetExtension(entity.FileName)}";

            using (var memory = new MemoryStream())
            {
                command.Entity.File.CopyTo(memory);
                await this.documentStorageManager.SaveDocument(fullName, memory.ToArray());
            }

            entity.FilePath = fullName;

            await this.repository.SaveAsync();

            if (command.Entity.AttachmentType == DocumenType.Closure)
            {
                var activity = new ActivityVM()
                {
                    EntityId = (Guid)command.Entity.EntityId,
                    ReferenceId = command.Entity.ReferanceId,
                    Comment = $"Gate closure document({command.Entity.File.FileName}) attached",
                    ActivityName = ActivityType.GateClosureDocument.DescriptionAttribute(),
                    ActivityType = ActivityType.GateClosureDocument,
                };
                await this.activityManager.SaveActivity(activity);
            }

            return new AttachmentDetailVM
            {
                Id = entity.Id,
                FileName = entity.FileName,
                ContentType = entity.ContentType,
                DocumentTypeId = entity.DocumentTypeId,
                FileSize = entity.FileSize
            };
        }

        /// <summary>
        /// Sets the attachment entity.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="attachments">The attachments.</param>
        /// <returns>
        /// List of AttachmentDetailVM.
        /// </returns>
        public async Task<List<AttachmentDetailVM>> SetAttachmentEntity(Guid entityId, List<AttachmentDetailVM> attachments)
        {
            if (attachments != null && attachments.Any())
            {
                foreach (var attachment in attachments)
                {
                    // if (attachment.DocumentType == DocumenType.CompanyLogo)
                    // {
                    //     this.repository.GetAll(x => x.Id != attachment.Id && x.EntityId == entityId && x.IsDeleted == false).ToList().ForEach(x => x.IsDeleted = true);
                    // }
                    var entity = await this.repository.FirstOrDefaultAsync(x => x.Id == attachment.Id && x.IsDeleted == false);
                    if (entity != null)
                    {
                        entity.EntityId = entityId;
                        attachment.EntityId = entityId;
                        entity.CompanyId = attachment.CompanyId;
                        this.repository.Update(entity);
                    }
                }
            }

            await this.repository.SaveAsync();

            return attachments;
        }

        /// <summary>
        /// Clones the document.
        /// </summary>
        /// <param name="attachment">The attachment.</param>
        /// <returns>
        /// AttachmentDetailVM.
        /// </returns>
        public async Task<AttachmentDetailVM> CloneDocument(AttachmentDetailVM attachment)
        {
            var entity = await this.repository.FirstOrDefaultAsync(x => x.Id == attachment.Id && x.IsDeleted == false);
            if (entity != null)
            {
                string fullName = $"RFQ/{entity.Id}{Path.GetExtension(entity.FilePath)}";

                await this.documentStorageManager.CloneDocument(entity.FilePath, fullName);
                entity.FilePath = fullName;
                await this.repository.SaveAsync();
            }

            return attachment;
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>The index.</returns>
        private static int GetIndex(string parameterName)
        {
            var start = parameterName.IndexOf("[", StringComparison.Ordinal) + 1;
            var end = parameterName.IndexOf("]", start, StringComparison.Ordinal);
            return int.Parse(parameterName.Substring(start, end - start));
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>The property name.</returns>
        private static string GetPropertyName(string parameterName)
        {
            var start = parameterName.LastIndexOf("[", StringComparison.Ordinal) + 1;
            var end = parameterName.IndexOf("]", start, StringComparison.Ordinal);
            return parameterName.Substring(start, end - start);
        }

        /// <summary>
        /// Adds the parameter to dictionary.
        /// </summary>
        /// <param name="customData">The custom data.</param>
        /// <param name="index">The index.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="value">The value.</param>
        private static void AddParameterToDictionary(Dictionary<int, Document> customData, int index, string parameterName, string value)
        {
            if (!customData.ContainsKey(index))
            {
                customData.Add(index, new Document());
            }

            var data = customData[index];

            switch (parameterName)
            {
                case "DocumenType":
                    // data.DocumenType = (DocumenType)Enum.Parse(typeof(DocumenType), value);
                    break;
                case "EntityId":
                    data.EntityId = Guid.Parse(value);
                    break;
            }
        }
    }
}
