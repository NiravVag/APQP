// <copyright file="APQPDiscussionManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.APQP
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Command.APQP.APQPDiscussion;
    using MESHWorksAPQP.Management.Helpers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;
    using MESHWorksAPQP.Management.Interface.Managers.Document;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.APQP.Discussion;
    using MESHWorksAPQP.Model.Models.Discussions;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.APQP;
    using MESHWorksAPQP.Shared.Enum;
    using APQPEntity= MESHWorksAPQP.Model.Models.APQP;

    /// <summary>
    /// Class APQPDiscussionManager.
    /// </summary>
    public class APQPDiscussionManager : IAPQPDiscussionManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The apqp repository
        /// </summary>
        private readonly IAPQPRepository apqpRepository;

        /// <summary>
        /// The discussion repository
        /// </summary>
        private readonly IGenericRepository<Discussion> discussionRepository;

        /// <summary>
        /// The document type repository
        /// </summary>
        private readonly ISetupRepositoty<DocumentType> documentTypeRepository;

        /// <summary>
        /// The document attachment manager.
        /// </summary>
        private readonly IDocumentAttachmentManager documentAttachmentManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="APQPDiscussionManager" /> class.
        /// </summary>
        /// <param name="mapper">
        /// The mapper.
        /// </param>
        /// <param name="apqpRepository">
        /// The apqp repository.
        /// </param>
        /// <param name="discussionRepository">
        /// The discussion repository.
        /// </param>
        /// <param name="documentTypeRepository">
        /// The document type repository.
        /// </param>
        /// <param name="documentAttachmentManager">
        /// The document attachment manager.
        /// </param>
        public APQPDiscussionManager(IMapper mapper, IAPQPRepository apqpRepository, IGenericRepository<Discussion> discussionRepository, IDocumentAttachmentManager documentAttachmentManager, ISetupRepositoty<DocumentType> documentTypeRepository)
        {
            this.mapper = mapper;
            this.apqpRepository = apqpRepository;
            this.discussionRepository = discussionRepository;
            this.documentTypeRepository = documentTypeRepository;
            this.documentAttachmentManager = documentAttachmentManager;
        }

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// Page of APQPDiscussionListVM.
        /// </returns>
        public async Task<Page<APQPDiscussionListVM>> Search(SearchAPQPDiscussionCommand command)
        {
            if (command.APQPId != Guid.Empty)
            {
                var discussions = await this.apqpRepository.GetAPQPDiscussions(command.APQPId, command.CompanyId);

                return await Task.FromResult(new Page<APQPDiscussionListVM>()
                {
                    Items = discussions.AsQueryable().ProjectTo<APQPDiscussionListVM>(this.mapper.ConfigurationProvider).ToList()
                });
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// APQPDiscussionVM.
        /// </returns>
        public async Task<APQPDiscussionVM> Get(GetAPQPDiscussionCommand command)
        {
            var apqp = await this.GetAPQP(command.Id, command.CompanyId);

            if (apqp != null && command.Id != Guid.Empty)
            {
                var discussionEntity = await this.discussionRepository.FirstOrDefaultAsync(x => x.Id == command.Id && x.APQPId == command.APQPId && x.CompanyId == command.CompanyId && !x.IsDeleted);
                if (discussionEntity != null)
                {
                    var discussion = this.mapper.Map<APQPDiscussionVM>(discussionEntity);
                    if (discussion.ParentDiscussionId != null || discussion.ParentDiscussionId != Guid.Empty)
                    {
                        var parentDiscussionEntity = await this.discussionRepository.FirstOrDefaultAsync(x => x.Id == discussion.ParentDiscussionId && x.APQPId == command.APQPId && !x.IsDeleted);
                        discussion.ParentNotes = parentDiscussionEntity.Notes;
                    }

                    var documentType = await this.GetDocumentType();

                    discussion.Attachments = await this.documentAttachmentManager.GetAttachments(discussion.Id, documentType.Id);
                    discussion.APQPName = apqp.Name;

                    return discussion;
                }
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// APQPDiscussionVM
        /// </returns>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">
        /// Invalid APQP Discussion.
        /// or
        /// Invalid Request.
        /// </exception>
        public async Task<APQPDiscussionVM> Save(SaveAPQPDiscussionCommand command)
        {
            if (command.Entity != null && command.APQPId != Guid.Empty && command.Entity.UserId != Guid.Empty && !string.IsNullOrWhiteSpace(command.Entity.Notes))
            {
                var entity = await this.GetAPQP(command.APQPId, command.CompanyId);

                Discussion discussion = null;
                if (command.Id != null && command.Id.HasValue && command.Id.Value != Guid.Empty)
                {
                    discussion = await this.discussionRepository.FirstOrDefaultAsync(x => x.Id == command.Id && x.APQPId == command.APQPId && x.CompanyId == command.Entity.CompanyId && !x.IsDeleted);

                    if (discussion == null)
                    {
                        throw new ValidationException("Invalid APQP Discussion.");
                    }

                    if (command.Entity.UserId != discussion.UserId)
                    {
                        throw new ValidationException("Invalid Request.");
                    }

                    this.mapper.Map(command.Entity, discussion);
                    discussion.IsDeleted = false;
                    this.discussionRepository.Update(discussion);
                }
                else
                {
                    discussion = this.mapper.Map<Discussion>(command.Entity);
                    this.discussionRepository.Create(discussion);
                }

                await this.discussionRepository.SaveAsync();

                if (command.Entity.Attachments != null && command.Entity.Attachments.Any())
                {
                    command.Entity.Attachments.ForEach(x =>
                    {
                        x.CompanyId = command.CompanyId;
                    });

                    await this.documentAttachmentManager.SetAttachmentEntity(discussion.Id, command.Entity.Attachments);
                }

                command.Entity.Id = discussion.Id;
                return command.Entity;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Deletes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// bool.
        /// </returns>
        public async Task<bool> Delete(DeleteAPQPDiscussionCommand command)
        {
            var entity = await this.GetAPQP(command.APQPId, command.CompanyId);

            var discussion = await this.discussionRepository.FirstOrDefaultAsync(x => x.Id == command.Id && x.APQPId == command.APQPId && x.CompanyId == command.CompanyId && !x.IsDeleted);

            if (discussion == null || command.UserId != discussion.UserId)
            {
                throw new ValidationException("Invalid Request.");
            }

            discussion.IsDeleted = true;
            this.discussionRepository.Update(discussion);

            await this.discussionRepository.SaveAsync();
            return true;
        }

        /// <summary>
        /// Gets the apqp.
        /// </summary>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>APQP</returns>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">APQP not found.</exception>
        private async Task<APQPEntity.APQP> GetAPQP(Guid apqpId, Guid companyId)
        {
            var entity = await this.apqpRepository.FirstOrDefaultAsync(x => x.Id == apqpId && x.CompanyId.Value == companyId && !x.IsDeleted);

            if (entity == null)
            {
                throw new ValidationException("APQP not found.");
            }

            return entity;
        }

        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <returns>DocumentType</returns>
        private async Task<DocumentType> GetDocumentType()
        {
            return await this.documentTypeRepository.FirstOrDefaultAsync(x => x.Code == DocumenType.Discussion.DescriptionAttribute() && !x.IsDeleted);
        }
    }
}
