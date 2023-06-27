// <copyright file="WorkFlowManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.APQP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EmailProvider.Interface.Managers;
    using EmailProvider.ViewModels;
    using MESHWorksAPQP.Management.Command.APQP.WorkFlow;
    using MESHWorksAPQP.Management.Helpers;
    using MESHWorksAPQP.Management.Interface.Managers.Activity;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;
    using MESHWorksAPQP.Management.Interface.Managers.Document;
    using MESHWorksAPQP.Management.Interface.Managers.Lookup;
    using MESHWorksAPQP.Management.Interface.Settings;
    using MESHWorksAPQP.Management.ViewModel.Activity;
    using MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow;
    using MESHWorksAPQP.Management.ViewModel.Lookup;
    using MESHWorksAPQP.Model.Models.APQP;
    using MESHWorksAPQP.Model.Models.APQP.Gates;
    using MESHWorksAPQP.Model.Models.APQP.WorkFlow;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Shared.Enum;
    using MESHWorksAPQP.Shared.Interface;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    ///  class WorkFlowManager.
    /// </summary>
    public class WorkFlowManager : IWorkFlowManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IGenericRepository<GateClosure> repository;

        /// <summary>
        /// The gate closure setting repository.
        /// </summary>
        private readonly IGenericRepository<GateClosureSetting> gateClosureSettingRepository;

        /// <summary>
        /// The gate closure email repository.
        /// </summary>
        private readonly IGenericRepository<GateClosureEmail> gateClosureEmailRepository;

        /// <summary>
        /// The gate closure document repository.
        /// </summary>
        private readonly IGenericRepository<GateClosureDocument> gateClosureDocumentRepository;

        /// <summary>
        /// The gate closure approval repository.
        /// </summary>
        private readonly IGenericRepository<GateClosureApproval> gateClosureApprovalRepository;

        /// <summary>
        /// The gate closure approval repository.
        /// </summary>
        private readonly IGenericRepository<APQP> apqpRepository;

        /// <summary>
        /// The gate closure repository
        /// </summary>
        private readonly IGenericRepository<GateClosure> gateClosureRepository;

        /// <summary>
        /// The approver repository
        /// </summary>
        private readonly IGenericRepository<Approver> approverRepository;

        /// <summary>
        /// The gate repository
        /// </summary>
        private readonly IGenericRepository<Gate> gateRepository;

        /// <summary>
        /// The approver action repository
        /// </summary>
        private readonly IGenericRepository<ApproverAction> approverActionRepository;

        /// <summary>
        /// The email manager.
        /// </summary>
        private readonly IEmailManager emailManager;

        /// <summary>
        /// The document attachment manager.
        /// </summary>
        private readonly IDocumentAttachmentManager documentAttachmentManager;

        /// <summary>
        /// The lookup manager
        /// </summary>
        private readonly ILookupManager lookupManager;

        /// <summary>
        /// The application settings.
        /// </summary>
        private readonly IAppSettings appSettings;

        /// <summary>
        /// The activity manager
        /// </summary>
        private readonly IActivityManager activityManager;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkFlowManager" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="gateClosureSettingRepository">The gate closure setting repository.</param>
        /// <param name="gateClosureEmailRepository">The gate closure email repository.</param>
        /// <param name="gateClosureDocumentRepository">The gate closure document repository.</param>
        /// <param name="gateClosureApprovalRepository">The gate closure approval repository.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="emailManager">The emailManager.</param>
        /// <param name="documentAttachmentManager">The documentAttachmentManager.</param>
        /// <param name="apqpRepository">The apqpRepository.</param>
        /// <param name="gateClosureRepository">The gateClosureRepository.</param>
        /// <param name="approverRepository">The approverRepository.</param>
        /// <param name="approverActionRepository">The approverActionRepository.</param>
        /// <param name="lookupManager">The lookupManager.</param>
        /// <param name="appSettings">The appSettings.</param>
        /// <param name="activityManager">The activity manager.</param>
        /// <param name="gateRepository">The gateRepository.</param>
        /// <param name="userIdentity">The userIdentity.</param>
        public WorkFlowManager(
         IMapper mapper,
         IGenericRepository<GateClosureSetting> gateClosureSettingRepository,
         IGenericRepository<GateClosureEmail> gateClosureEmailRepository,
         IGenericRepository<GateClosureDocument> gateClosureDocumentRepository,
         IGenericRepository<GateClosureApproval> gateClosureApprovalRepository,
         IGenericRepository<GateClosure> repository,
         IEmailManager emailManager,
         IDocumentAttachmentManager documentAttachmentManager,
         IGenericRepository<APQP> apqpRepository,
         IGenericRepository<GateClosure> gateClosureRepository,
         IGenericRepository<Approver> approverRepository,
         IGenericRepository<ApproverAction> approverActionRepository,
         ILookupManager lookupManager,
         IAppSettings appSettings,
         IActivityManager activityManager,
         IGenericRepository<Gate> gateRepository,
         IUserIdentity userIdentity)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.gateClosureSettingRepository = gateClosureSettingRepository;
            this.gateClosureEmailRepository = gateClosureEmailRepository;
            this.gateClosureDocumentRepository = gateClosureDocumentRepository;
            this.gateClosureApprovalRepository = gateClosureApprovalRepository;
            this.emailManager = emailManager;
            this.documentAttachmentManager = documentAttachmentManager;
            this.apqpRepository = apqpRepository;
            this.gateClosureRepository = gateClosureRepository;
            this.approverRepository = approverRepository;
            this.approverActionRepository = approverActionRepository;
            this.lookupManager = lookupManager;
            this.appSettings = appSettings;
            this.activityManager = activityManager;
            this.gateRepository = gateRepository;
            this.userIdentity = userIdentity;
        }

        /// <summary>
        /// Saves the gate closure document.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// GateClosureSettingVM.
        /// </returns>
        public async Task<GateClosureSettingVM> SaveGateClosureDocument(GateClosureCommand command)
        {
            bool isAllDoumentsAttched = false;
            try
            {
                var gateClosureDocumentConfigs = this.gateClosureDocumentRepository.GetAll(x => !x.IsDeleted && x.GateClosureSettingId == command.Entity.GateClosureDocument.GateClosureSettingId);
                if (gateClosureDocumentConfigs != null && gateClosureDocumentConfigs.Any()
                    && command?.Entity?.GateClosureDocument?.DocumentAttachments != null && command.Entity.GateClosureDocument.DocumentAttachments.Any())
                {
                    var closureDocsTypeIds = gateClosureDocumentConfigs.Select(x => x.DocumentTypeId).ToList();
                    var attachments = await this.documentAttachmentManager.GetAttachments(command.APQPId, null, command.Entity?.GateId);
                    var attchedDocsTypeIds = attachments.Select(x => x.DocumentTypeId).Distinct().ToList();
                    isAllDoumentsAttched = closureDocsTypeIds.Intersect(attchedDocsTypeIds).Count() == closureDocsTypeIds.Count();

                    command.Entity.GateClosureDocument.DocumentAttachments.ForEach(x =>
                    {
                        x.CompanyId = command.CompanyId.Value;
                    });

                    await this.documentAttachmentManager.SetAttachmentEntity(command.APQPId, command.Entity.GateClosureDocument.DocumentAttachments);
                }

                bool isAlreadyClosureCompleted = command.Entity.Completed;
                command.Entity.Completed = isAllDoumentsAttched;
                await this.SaveGateClosure(command.Entity.Id, command.APQPId, command.Entity.ClouserType, isAllDoumentsAttched);

                if (isAllDoumentsAttched != isAlreadyClosureCompleted)
                {
                    var activity = new ActivityVM()
                    {
                        EntityId = command.APQPId,
                        ReferenceId = command.Entity.GateId,
                        Comment = "Gate closure - All documents attached",
                        ActivityName = ActivityType.GateClosureDocument.DescriptionAttribute(),
                        ActivityType = ActivityType.GateClosureDocument,
                    };
                    await this.activityManager.SaveActivity(activity);
                }

                return command.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sends the gate closure email.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// GateClosureSettingVM.
        /// </returns>
        public async Task<GateClosureSettingVM> SendGateClosureEmail(GateClosureCommand command)
        {
            try
            {
                var companyUsers = await this.GetEmailAddressAsync(command.CompanyId);
                var emailRecipientIds = command.Entity.GateClosureEmail.To?.Split(";")?.Select(Guid.Parse).ToList() ?? new List<Guid>();
                var ccEmailRecipientIds = new List<Guid>();
                if (!string.IsNullOrWhiteSpace(command.Entity?.GateClosureEmail?.CC))
                {
                    ccEmailRecipientIds = command.Entity.GateClosureEmail.CC?.Split(";")?.Select(Guid.Parse).ToList() ?? new List<Guid>();
                }

                var apqpProject = await this.apqpRepository.FirstOrDefaultAsync(x => x.Id == command.APQPId);

                var emailModel = new EmailProvider.ViewModels.GateClosureEmailVM()
                {
                    To = companyUsers.Where(x => emailRecipientIds.Contains((Guid)x.Id))?.Select(x => x.Code)?.ToList(),
                    CC = ccEmailRecipientIds.Any() ? companyUsers.Where(x => ccEmailRecipientIds.Contains((Guid)x.Id))?.Select(x => x.Code)?.Aggregate((a, b) => a + ";" + b) : string.Empty,
                    Subject = command.Entity.GateClosureEmail.Subject,
                    Message = command.Entity.GateClosureEmail.Message,
                    ClosureEmailRecipient = emailRecipientIds.Any() ? companyUsers.Where(x => emailRecipientIds.Contains((Guid)x.Id))?.Select(x => x.Name)?.Aggregate((a, b) => a + "," + b) : string.Empty,
                    ApqpProjectLink = $"{this.appSettings.FrontendURL}/apqp/project/{command.APQPId}/part/{apqpProject.PartId}",
                    ClosureEmailSender = companyUsers.FirstOrDefault(x => (Guid)x.Id == this.userIdentity.UserInfo.Id)?.Name,
                };

                var activity = new ActivityVM()
                {
                    EntityId = command.APQPId,
                    ReferenceId = command.Entity.GateClosureEmail.Id,
                    Comment = "Closure email sent",
                    ActivityName = ActivityType.GateClosureEmail.DescriptionAttribute(),
                    ActivityType = ActivityType.GateClosureEmail,
                };
                await this.activityManager.SaveActivity(activity);

                await this.emailManager.SendGateClosureEmail(emailModel);

                command.Entity.Completed = await this.SaveGateClosure(command.Entity.Id, command.APQPId, command.Entity.ClouserType, true);
                return command.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates the active gate identifier.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>bool.</returns>
        public async Task<bool> UpdateActiveGateId(UpdateActiveGateIdCommand command)
        {
            var entity = await this.apqpRepository.FirstOrDefaultAsync(x => x.Id == command.Id && !x.IsDeleted);

            if (entity != null)
            {
                var comment = string.Empty;
                if (entity.ActiveGateId != null)
                {
                    var previousGate = await this.gateRepository.FirstOrDefaultAsync(x => x.Id == entity.ActiveGateId);
                    comment = $"Moved from {previousGate?.Name} ";
                }

                var nextGate = await this.gateRepository.FirstOrDefaultAsync(x => x.Id == command.GateId);
                if (nextGate != null)
                {
                    comment += $"to {nextGate?.Name}";
                }

                if (command.GateId != entity.ActiveGateId)
                {
                    var activity = new ActivityVM()
                    {
                        EntityId = entity.Id,
                        ChildEntityId = command.GateId,
                        Comment = comment,
                        ActivityType = ActivityType.MovedToNextGate,
                        ActivityName = ActivityType.MovedToNextGate.DescriptionAttribute(),
                    };

                    await this.activityManager.SaveActivity(activity);

                    entity.ActiveGateId = command.GateId;

                    await this.apqpRepository.SaveAsync();

                    return true;
                }

                throw new ValidationException("Invalid Request.");
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public async Task<bool> UpdateStatus(UpdateGateStatusCommand command)
        {
            var entity = await this.apqpRepository.FirstOrDefaultAsync(x => x.Id == command.Entity.Id);

            if (entity != null)
            {
                var activity = new ActivityVM();
                switch (command.Entity.Activity)
                {
                    case ActivityType.APQPProjectCompleted:
                        if (entity.Status == APQPStatus.Completed)
                        {
                            throw new ValidationException("APQP Project is already" + entity.Status);
                        }

                        activity.ActivityType = ActivityType.APQPProjectCompleted;
                        activity.ActivityName = ActivityType.APQPProjectCompleted.DescriptionAttribute();
                        entity.Status = APQPStatus.Completed;
                        break;
                    case ActivityType.APQPProjectReopened:
                        if (entity.Status == APQPStatus.InProgress)
                        {
                            throw new ValidationException("APQP Project is already" + entity.Status);
                        }

                        activity.ActivityType = ActivityType.APQPProjectReopened;
                        activity.ActivityName = ActivityType.APQPProjectReopened.DescriptionAttribute();
                        entity.Status = APQPStatus.InProgress;                     
                        break;
                    case ActivityType.APQPProjectDeleted:
                        if (entity.Status == APQPStatus.Deleted)
                        {
                            throw new ValidationException("APQP Project is already" + entity.Status);
                        }

                        if (entity.Status == APQPStatus.Completed)
                        {
                            throw new ValidationException("APQP Project Status can not update from Complete to Deleted.");
                        }

                        activity.ActivityType = ActivityType.APQPProjectDeleted;
                        activity.ActivityName = ActivityType.APQPProjectDeleted.DescriptionAttribute();
                        entity.Status = APQPStatus.Deleted;
                        break;
                }

                activity.EntityId = entity.Id;
                activity.ChildEntityId = command.Entity.GateID;
                activity.Comment = command.Entity.Comment;
                this.apqpRepository.Update(entity);
                await this.apqpRepository.SaveAsync();
                await this.activityManager.SaveActivity(activity);
                return true;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Gets the gate closure status.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of GateClouserVM.</returns>
        public async Task<List<GateClouserVM>> GetGateClosureStatus(GetGateClosureStatusCommand command)
        {
            var gateClosureSettingEntity = this.gateClosureSettingRepository.GetAll(x => !x.IsDeleted && x.GateId == command.GateId);
            var entity = this.gateClosureRepository.GetAll(x => !x.IsDeleted && x.ClosureReferenceId == command.Id);
            if (gateClosureSettingEntity != null && entity != null)
            {
                var gateClosureSettingIds = gateClosureSettingEntity.Select(x => x.Id).ToList();
                entity = entity.Where(x => gateClosureSettingIds.Contains(x.GateClosureSettingId));
            }

            if (entity != null)
            {
                return entity.AsQueryable().ProjectTo<GateClouserVM>(this.mapper.ConfigurationProvider).ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Saves the gate closure approver action.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>ApproverActionVM.</returns>
        public async Task<GateClosureSettingVM> SaveGateClosureApproverAction(GateClosureCommand command)
        {
            if (command?.Entity?.GateClosureApproval != null)
            {
                var approver = command.Entity.GateClosureApproval.Approvers.FirstOrDefault(x => x.UserId == command.Entity.GateClosureApproval.UserId);
                if (approver != null)
                {
                    var entity = await this.approverActionRepository.FirstOrDefaultAsync(x => !x.IsDeleted
                    && x.ClosureReferenceId == command.APQPId
                    && x.GateClosureApprovalId == command.Entity.GateClosureApproval.Id
                    && x.UserId == command.Entity.GateClosureApproval.UserId);

                    var currentApprovalStatus = entity?.ApprovalStatus;

                    if (entity == null)
                    {
                        entity = new ApproverAction()
                        {
                            ClosureReferenceId = command.APQPId,
                            ApprovalStatus = approver.ApprovalStatus,
                            Comment = approver.Comment,
                            GateClosureApprovalId = approver.GateClosureApprovalId,
                            UserId = approver.UserId,
                        };

                        this.approverActionRepository.Create(entity);
                    }
                    else
                    {
                        entity.ApprovalStatus = approver.ApprovalStatus;
                        entity.Comment = approver.Comment;
                        this.approverActionRepository.Update(entity);
                    }

                    if (currentApprovalStatus != entity.ApprovalStatus && entity.ApprovalStatus != ApprovalStatus.Pending)
                    {
                        var activity = new ActivityVM()
                        {
                            EntityId = command.APQPId,
                            ReferenceId = approver.GateClosureApprovalId,
                            Comment = approver.Comment,
                            ActivityName = $"{ActivityType.GateClosureApproverAction.DescriptionAttribute()} - {approver.ApprovalStatus}",
                            ActivityType = ActivityType.GateClosureApproverAction,
                        };
                        await this.activityManager.SaveActivity(activity);
                    }

                    await this.approverActionRepository.SaveAsync();

                    var gateClosureSetting = await this.SaveGateClosureApprovals(command, approver.ApprovalStatus, approver.UserId);

                    return command.Entity = gateClosureSetting;
                }
            }

            return null;
        }

        /// <summary>
        /// Sends the gate closure approval request.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>bool.</returns>
        public async Task<bool> RequestGateClosureApprovalCommand(RequestGateClosureApprovalCommand command)
        {
            var emailRecipientIds = new List<Guid>();

            if (command?.Entity?.APQPId != null && command.Entity.APQPId != default(Guid))
            {
                var gateClosureApprovalconfig = await this.gateClosureApprovalRepository.FirstOrDefaultAsync(x => x.GateClosureSettingId == command.Entity.GateClosureApprovalSettingId);

                if (gateClosureApprovalconfig != null)
                {
                    if (gateClosureApprovalconfig.ApprovalType == ApprovalType.Chain)
                    {
                        var nextApprover = gateClosureApprovalconfig.Approvers.FirstOrDefault(x => x.ChainOrder == 1);
                        if (nextApprover != null)
                        {
                            emailRecipientIds.Add(nextApprover.UserId);
                        }
                    }
                    else
                    {
                        if (gateClosureApprovalconfig.Approvers != null && gateClosureApprovalconfig.Approvers.Any())
                        {
                            emailRecipientIds = gateClosureApprovalconfig.Approvers.Select(x => x.UserId).ToList();
                        }
                    }

                    await this.activityManager.SaveActivity(new ActivityVM()
                    {
                        EntityId = command.Entity.APQPId,
                        ReferenceId = command.Entity.GateClosureApprovalSettingId,
                        ChildEntityId = command.Entity.GateId,
                        Comment = command.Entity.Comment,
                        ActivityType = ActivityType.GateClosureApprovalRequest,
                        ActivityName = ActivityType.GateClosureApprovalRequest.DescriptionAttribute()
                    });

                    await this.SaveGateClosure(command.Entity.GateClosureApprovalSettingId, command.Entity.APQPId, ClouserType.Approval, false);
                    await this.SendApprovalRequestEmail((Guid)command.CompanyId, emailRecipientIds, command.Entity.APQPId, command.Entity.GateId, command.Entity.UserId, command.Entity.Comment);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// ReOpen gate.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>bool.</returns>
        public async Task<bool> ReOpenGate(ReOpenGateCommand command)
        {
            if (command?.Entity?.APQPId != null && command.Entity.APQPId != default(Guid))
            {
                var apqp = await this.apqpRepository.FirstOrDefaultAsync(x => x.Id == command.Entity.APQPId);
                if (apqp != null)
                {
                    apqp.ActiveGateId = command.Entity.GateId;
                    this.apqpRepository.Update(apqp);
                    await this.apqpRepository.SaveAsync();
                    var selectedGate = await this.gateRepository.FirstOrDefaultAsync(x => x.Id == command.Entity.GateId && x.APQPTemplateId == apqp.APQPTemplateId);
                    var activityVM = new ActivityVM()
                    {
                        EntityId = command.Entity.APQPId,
                        ChildEntityId = command.Entity.GateId,
                        Comment = command.Entity.Comment,
                        ActivityType = ActivityType.ReOpenGate,
                        ActivityName = selectedGate.Name + "has been reopened."
                    };
                    await this.activityManager.SaveActivity(activityVM);
                    if (selectedGate != null)
                    {
                        var gates = this.gateRepository.GetAll().Where(x => x.APQPTemplateId == apqp.APQPTemplateId && x.SortOrder >= selectedGate.SortOrder).ToList();
                        if (gates != null && gates.Any())
                        {
                            foreach (var gate in gates)
                            {
                                var gateClosureSettings = this.gateClosureSettingRepository.GetAll().Where(x => !x.IsDeleted && x.GateId == gate.Id && x.ClouserType != ClouserType.Document).ToList();
                                if (gateClosureSettings != null && gateClosureSettings.Any())
                                {
                                    foreach (var gateClosureSetting in gateClosureSettings)
                                    {
                                        if (gateClosureSetting.ClouserType == ClouserType.Approval)
                                        {
                                            var gateClosureApproval = await this.gateClosureApprovalRepository.FirstOrDefaultAsync(x => !x.IsDeleted && x.GateClosureSettingId == gateClosureSetting.Id);
                                            if (gateClosureApproval != null)
                                            {
                                                var approverActions = this.approverActionRepository.GetAll().Where(x => !x.IsDeleted &&
                                                x.ClosureReferenceId == apqp.Id && x.GateClosureApprovalId == gateClosureApproval.Id).ToList();
                                                if (approverActions != null && approverActions.Any())
                                                {
                                                    foreach (var approverAction in approverActions)
                                                    {
                                                        approverAction.IsDeleted = true;
                                                        this.approverActionRepository.Update(approverAction);
                                                    }

                                                    await this.approverActionRepository.SaveAsync();
                                                }
                                            }

                                            var gateClosure = await this.repository.FirstOrDefaultAsync(x => !x.IsDeleted && x.GateClosureSettingId == gateClosureSetting.Id
                                            && x.ClosureReferenceId == apqp.Id && x.ClouserType == gateClosureSetting.ClouserType);
                                            if (gateClosure != null)
                                            {
                                                gateClosure.IsDeleted = true;
                                                this.repository.Update(gateClosure);
                                                await this.repository.SaveAsync();
                                            }
                                        }
                                        else if (gateClosureSetting.ClouserType == ClouserType.Email)
                                        {
                                            var gateClosure = await this.repository.FirstOrDefaultAsync(x => !x.IsDeleted && x.GateClosureSettingId == gateClosureSetting.Id
                                            && x.ClosureReferenceId == apqp.Id && x.ClouserType == gateClosureSetting.ClouserType);
                                            if (gateClosure != null)
                                            {
                                                gateClosure.IsDeleted = true;
                                                this.repository.Update(gateClosure);
                                                await this.repository.SaveAsync();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Saves the gate closure approvals.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>GateClosureSettingVM.</returns>
        private async Task<GateClosureSettingVM> SaveGateClosureApprovals(GateClosureCommand command, ApprovalStatus approvalStatus, Guid approverId)
        {
            bool isApproved = false;
            var emailRecipientIds = new List<Guid>();
            Approver approver = null;
            try
            {
                if (command?.Entity?.GateClosureApproval != null)
                {
                    approver = await this.approverRepository.FirstOrDefaultAsync(x => x.GateClosureApprovalId == command.Entity.GateClosureApproval.Id && x.UserId == approverId);

                    switch (command.Entity.GateClosureApproval.ApprovalType)
                    {
                        case ApprovalType.Basic:
                            if (approver != null)
                            {
                                var approverAction = await this.approverActionRepository.FirstOrDefaultAsync(x => x.GateClosureApprovalId == command.Entity.GateClosureApproval.Id && x.ClosureReferenceId == command.APQPId && x.UserId == approver.UserId && x.ApprovalStatus == ApprovalStatus.Approved);
                                isApproved = approverAction != null ? true : false;
                                emailRecipientIds.Add(approver.UserId);
                            }

                            break;
                        case ApprovalType.Advance:

                            var approvers = this.approverRepository.GetAll(x => x.GateClosureApprovalId == command.Entity.GateClosureApproval.Id);
                            if (approvers != null && approvers.Any())
                            {
                                emailRecipientIds = approvers.Select(x => x.UserId).ToList();
                                var requiredapprovers = approvers.Where(x => x.RequiredApprover);
                                var approversIds = approvers.Select(x => x.UserId);
                                var approverActions = this.approverActionRepository.GetAll(x => !x.IsDeleted && x.GateClosureApprovalId == command.Entity.GateClosureApproval.Id && x.ClosureReferenceId == command.APQPId && approversIds.Contains(x.UserId) && x.ApprovalStatus == ApprovalStatus.Approved);
                                if (approverActions != null && approverActions.Any())
                                {
                                    if (command.Entity.GateClosureApproval.MinApprover <= approverActions.Count())
                                    {
                                        if (requiredapprovers == null || !requiredapprovers.Any())
                                        {
                                            isApproved = true;
                                        }
                                        else if (requiredapprovers.Any())
                                        {
                                            var requiredapproversIds = requiredapprovers.Select(x => x.UserId);
                                            var approverActionsIds = approverActions.Select(x => x.UserId);
                                            isApproved = requiredapproversIds.Intersect(approverActionsIds).Count() == requiredapproversIds.Count();
                                        }
                                    }
                                }
                            }

                            break;
                        case ApprovalType.Chain:
                            var chainFlowApprovers = this.approverRepository.GetAll(x => x.GateClosureApprovalId == command.Entity.GateClosureApproval.Id)?.OrderBy(x => x.ChainOrder);
                            if (chainFlowApprovers != null && chainFlowApprovers.Any())
                            {
                                var approversIds = chainFlowApprovers.Select(x => x.UserId).ToList();
                                var approverActions = this.approverActionRepository.GetAll(x => !x.IsDeleted && x.GateClosureApprovalId == command.Entity.GateClosureApproval.Id && x.ClosureReferenceId == command.APQPId && approversIds.Contains(x.UserId) && x.ApprovalStatus == ApprovalStatus.Approved);
                                if (approverActions != null && approverActions.Any() && chainFlowApprovers.Count() == approverActions.Count())
                                {
                                    isApproved = true;
                                }
                            }

                            if (!isApproved)
                            {
                                var lastApproverOrder = approver.ChainOrder;
                                var nextApprover = chainFlowApprovers.FirstOrDefault(x => x.ChainOrder == (lastApproverOrder + 1));
                                if (nextApprover != null)
                                {
                                    emailRecipientIds.Add(nextApprover.UserId);
                                }
                            }
                            else
                            {
                                emailRecipientIds = chainFlowApprovers.Select(x => x.UserId).ToList();
                            }

                            break;
                    }
                }

                if (isApproved)
                {
                    await this.SaveGateClosure(command.Entity.Id, command.APQPId, command.Entity.ClouserType, true);
                    command.Entity.Completed = isApproved;
                }

                await this.SendApprovalActionEmail((Guid)command.CompanyId, emailRecipientIds, approvalStatus, command.APQPId, (Guid)command.Entity.GateId, approverId, isApproved);

                return command.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<List<LookupVM>> GetEmailAddressAsync(Guid? companyId)
        {
            List<LookupQuery> filters = new List<LookupQuery>();
            filters.Add(new LookupQuery
            {
                LookupType = LookupType.User,
                FilterParameters = new Dictionary<string, string> { { "CompanyId", companyId.ToString() } }
            });

            var lookups = await this.lookupManager.GetLookups(filters);

            return lookups.FirstOrDefault(x => x.Name.Equals("User"))?.Data?.ToList() ?? null;
        }

        /// <summary>
        /// Saves the gate closure.
        /// </summary>
        /// <param name="gateClosureSettingId">The gate closure setting identifier.</param>
        /// <param name="apqpId">The apqp identifier.</param>
        /// <param name="clouserType">Type of the clouser.</param>
        /// <param name="isCompleted">if set to <c>true</c> [is completed].</param>
        /// <returns>bool.</returns>
        private async Task<bool> SaveGateClosure(Guid gateClosureSettingId, Guid apqpId, ClouserType clouserType, bool isCompleted = false)
        {
            GateClosure entity = null;
            if (apqpId != default(Guid) && gateClosureSettingId != default(Guid))
            {
                entity = await this.repository.FirstOrDefaultAsync(x => !x.IsDeleted && x.GateClosureSettingId == gateClosureSettingId && x.ClosureReferenceId == apqpId);

                if (entity == null)
                {
                    GateClosure gateClosure = new GateClosure()
                    {
                        GateClosureSettingId = gateClosureSettingId,
                        IsCompleted = isCompleted,
                        ClosureReferenceId = apqpId,
                        ApprovalInProgress = !isCompleted,
                        ClouserType = clouserType,
                    };

                    this.repository.Create(gateClosure);
                }
                else
                {
                    entity.IsCompleted = isCompleted;
                    entity.ApprovalInProgress = !isCompleted;
                    this.repository.Update(entity);
                }

                await this.repository.SaveAsync();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Sends the approval action email.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="emailRecipientIds">The email recipient ids.</param>
        /// <param name="approvalStatus">The approval status.</param>
        /// <param name="isApproved">if set to <c>true</c> [is approved].</param>
        private async Task SendApprovalActionEmail(Guid companyId, List<Guid> emailRecipientIds, ApprovalStatus approvalStatus, Guid apqId, Guid gateId, Guid userId, bool isApproved = false)
        {
            var companyUsers = await this.GetEmailAddressAsync(companyId);
            var userName = companyUsers.FirstOrDefault(x => (Guid)x.Id == userId)?.Name;
            var apqp = await this.apqpRepository.FirstOrDefaultAsync(x => x.Id == apqId);
            var gateName = apqp.APQPTemplate.Gates.FirstOrDefault(x => x.Id == gateId)?.Name;

            var apqpProject = await this.apqpRepository.FirstOrDefaultAsync(x => x.Id == apqId);

            var emailModel = new GateClosureApprovalEmailVM()
            {
                To = companyUsers.Where(x => emailRecipientIds.Contains((Guid)x.Id))?.Select(x => x.Code)?.ToList(),
                Subject = $"Approval status for {apqp.Name} - {gateName} is changed",
                Message = $"{userName} changed the status to {approvalStatus.ToString()}",
                ApqpProjectLink = $"{this.appSettings.FrontendURL}/apqp/project/{apqId}/part/{apqpProject.PartId}",
                ApprovalStatus = isApproved ? "Approval completed" : "Waiting for approval",
            };
            await this.emailManager.GateClosureApprovalEmail(emailModel);
        }

        /// <summary>
        /// Sends the approval request email.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="emailRecipientIds">The email recipient ids.</param>
        /// <param name="apqId">The apq identifier.</param>
        /// <param name="gateId">The gate identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Task.</returns>
        private async Task SendApprovalRequestEmail(Guid companyId, List<Guid> emailRecipientIds, Guid apqId, Guid gateId, Guid userId, string comment)
        {
            var companyUsers = await this.GetEmailAddressAsync(companyId);
            var userName = companyUsers.FirstOrDefault(x => (Guid)x.Id == userId)?.Name;
            var apqp = await this.apqpRepository.FirstOrDefaultAsync(x => x.Id == apqId);
            var gateName = apqp.APQPTemplate.Gates.FirstOrDefault(x => x.Id == gateId)?.Name;
            var apqpProject = await this.apqpRepository.FirstOrDefaultAsync(x => x.Id == apqId);

            var emailModel = new RaiseGateClosureApprovalEmailVM()
            {
                To = companyUsers.Where(x => emailRecipientIds.Contains((Guid)x.Id))?.Select(x => x.Code)?.ToList(),
                Subject = $"Approval request for {apqp.Name} - {gateName}",
                Message = $"{userName} has raised approval request for {apqp.Name} - {gateName} <br/><br/><strong>Comment:</strong>{comment}",
                ApqpProjectLink = $"{this.appSettings.FrontendURL}/apqp/project/{apqId}/part/{apqpProject.PartId}",
                APQPProjectName = apqp.Name,
                GateName = gateName,
            };

            await this.emailManager.RaiseGateClosureApprovalEmail(emailModel);
        }

        public Task<bool> UpdateAPQPStatus(UpdateGateStatusCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
