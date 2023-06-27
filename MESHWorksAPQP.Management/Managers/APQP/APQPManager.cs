// <copyright file="APQPManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.APQP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Commands.APQP;
    using MESHWorksAPQP.Management.Interface.Managers.Activity;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;
    using MESHWorksAPQP.Management.Interface.Managers.Document;
    using MESHWorksAPQP.Management.Interface.Managers.Lookup;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Activity;
    using MESHWorksAPQP.Management.ViewModel.APQP.Gates;
    using MESHWorksAPQP.Management.ViewModel.Lookup;
    using MESHWorksAPQP.Model.Models.APQP;
    using MESHWorksAPQP.Model.Models.APQP.WorkFlow;
    using MESHWorksAPQP.Model.Models.CustomField;
    using MESHWorksAPQP.Repository.CustomModel.APQP;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.APQP;
    using MESHWorksAPQP.Shared.Enum;
    using MESHWorksAPQP.Shared.Models;
    using Newtonsoft.Json;
    using APQPTable = MESHWorksAPQP.Model.Models.APQP;

    // using Azure;

    /// <summary>
    /// class APQPManager.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Managers.APQP.IAPQPManager" />
    public class APQPManager : IAPQPManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IAPQPRepository repository;

        /// <summary>
        /// The apqp data repository
        /// </summary>
        private readonly IGenericRepository<APQPData> apqpDataRepository;

        /// <summary>
        /// The custom field answer repository
        /// </summary>
        private readonly IGenericRepository<CustomFieldAnswer> customFieldAnswerRepository;

        /// <summary>
        /// The gate closure setting repository
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
        /// The approver repository
        /// </summary>
        private readonly IGenericRepository<Approver> approverRepository;

        /// <summary>
        /// The approver action repository
        /// </summary>
        private readonly IGenericRepository<ApproverAction> approverActionRepository;

        /// <summary>
        /// The document attachment manager.
        /// </summary>
        private readonly IDocumentAttachmentManager documentAttachmentManager;

        /// <summary>
        /// The approver lookupManager
        /// </summary>
        private readonly ILookupManager lookupManager;

        /// <summary>
        /// The activity manager
        /// </summary>
        private readonly IActivityManager activityManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="APQPManager" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="apqpDataRepository">The apqp data repository.</param>
        /// <param name="customFieldAnswerRepository">The custom field answer repository.</param>
        /// <param name="gateClosureSettingRepository">The gateClosureSetting repository.</param>
        /// <param name="gateClosureEmailRepository">The gateClosureEmail repository.</param>
        /// <param name="gateClosureDocumentRepository">The gateClosureDocument repository.</param>
        /// <param name="gateClosureApprovalRepository">The gateClosureApproval repository.</param>
        /// <param name="documentAttachmentManager">The documentAttachmentManager.</param>
        /// <param name="approverRepository">The approverRepository.</param>
        /// <param name="approverActionRepository">The approverActionRepository.</param>
        /// <param name="activityManager">The activity manager.</param>
        /// <param name="lookupManager">The lookupManager.</param>
        public APQPManager(
            IMapper mapper,
            IAPQPRepository repository,
            IGenericRepository<APQPData> apqpDataRepository,
            IGenericRepository<CustomFieldAnswer> customFieldAnswerRepository,
            IGenericRepository<GateClosureSetting> gateClosureSettingRepository,
            IGenericRepository<GateClosureEmail> gateClosureEmailRepository,
            IGenericRepository<GateClosureDocument> gateClosureDocumentRepository,
            IGenericRepository<GateClosureApproval> gateClosureApprovalRepository,
            IDocumentAttachmentManager documentAttachmentManager,
            IGenericRepository<Approver> approverRepository,
            IGenericRepository<ApproverAction> approverActionRepository,
            IActivityManager activityManager,
            ILookupManager lookupManager)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.apqpDataRepository = apqpDataRepository;
            this.customFieldAnswerRepository = customFieldAnswerRepository;
            this.gateClosureSettingRepository = gateClosureSettingRepository;
            this.gateClosureEmailRepository = gateClosureEmailRepository;
            this.gateClosureDocumentRepository = gateClosureDocumentRepository;
            this.gateClosureApprovalRepository = gateClosureApprovalRepository;
            this.documentAttachmentManager = documentAttachmentManager;
            this.approverRepository = approverRepository;
            this.approverActionRepository = approverActionRepository;
            this.activityManager = activityManager;
            this.lookupManager = lookupManager;
        }

        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// TGetResult.
        /// </returns>
        public async Task<APQPCM> Get(GetAPQPCommand command)
        {
            var apqpTemplateDetails = await this.repository.GetAPQPTemplateDeatils(command.Id);

            var apqpData = await this.repository.GetAPQPData(command.Id);

            var gates = apqpTemplateDetails?.APQPTemplate?.Gates;

            if (gates != null && gates.Any())
            {
                foreach (var gate in gates)
                {
                    var gateClosureSettings = this.gateClosureSettingRepository.GetAll(x => !x.IsDeleted && x.GateId == gate.Id);
                    gate.GateClosureSettings = gateClosureSettings.AsQueryable().ProjectTo<GateClosureSettingCM>(this.mapper.ConfigurationProvider).ToList();

                    if (gate.GateClosureSettings != null && gate.GateClosureSettings.Any())
                    {
                        foreach (var gateClosure in gate.GateClosureSettings)
                        {
                            switch (gateClosure.ClouserType)
                            {
                                case Shared.Enum.ClouserType.Email:
                                    var gateClosureEmailConfig = await this.gateClosureEmailRepository.FirstOrDefaultAsync(x => !x.IsDeleted && x.GateClosureSettingId == gateClosure.Id);
                                    gateClosure.GateClosureEmail = gateClosureEmailConfig != null ? this.mapper.Map<GateClosureEmailCM>(gateClosureEmailConfig) : null;
                                    break;
                                case Shared.Enum.ClouserType.Document:
                                    var gateClosureDocumentConfigs = this.gateClosureDocumentRepository.GetAll(x => !x.IsDeleted && x.GateClosureSettingId == gateClosure.Id);
                                    gateClosure.GateClosureDocument = await this.GetGateClosureDocumentsAsync(command.Id, gateClosureDocumentConfigs, gate.Id);
                                    break;
                                case Shared.Enum.ClouserType.Approval:
                                    var gateClosureApprovalConfig = await this.gateClosureApprovalRepository.FirstOrDefaultAsync(x => !x.IsDeleted && x.GateClosureSettingId == gateClosure.Id);
                                    gateClosure.GateClosureApproval = gateClosureApprovalConfig != null ? this.mapper.Map<GateClosureApprovalCM>(gateClosureApprovalConfig) : null;

                                    var approvers = this.approverRepository.GetAll(x => !x.IsDeleted && x.GateClosureApprovalId == gateClosure.GateClosureApproval.Id);
                                    gateClosure.GateClosureApproval.Approvers = approvers.ProjectTo<ApproverCM>(this.mapper.ConfigurationProvider).ToList();

                                    var approverActions = this.approverActionRepository.GetAll(x => !x.IsDeleted && x.GateClosureApprovalId == gateClosure.GateClosureApproval.Id && x.ClosureReferenceId == command.Id);
                                    if (approvers != null && approvers.Any())
                                    {
                                        foreach (var approver in gateClosure.GateClosureApproval.Approvers)
                                        {
                                            var action = approverActions?.FirstOrDefault(x => !x.IsDeleted && x.UserId == approver.UserId);
                                            approver.Comment = action?.Comment;
                                            approver.ApprovalStatus = action?.ApprovalStatus ?? Shared.Enum.ApprovalStatus.Pending;
                                        }
                                    }

                                    break;
                            }

                            var closure = gate.GateClosures.FirstOrDefault(x => x.GateClosureSettingId == gateClosure.Id && x.ClosureReferenceId == command.Id);
                            if (closure != null)
                            {
                                gateClosure.Completed = closure.IsCompleted;
                                gateClosure.ApprovalInProgress = !closure.IsCompleted;
                            }
                        }
                    }

                    if (gate.CustomFields != null && gate.CustomFields.Any())
                    {
                        foreach (var customField in gate.CustomFields)
                        {
                            if (customField.IsPredefindField)
                            {
                                var answerValue = apqpData.GetType().GetProperty(customField.PredefindFieldName)?.GetValue(apqpData, null);
                                customField.CustomFieldAnswers = new List<CustomFieldAnswerCM>
                                {
                                    new CustomFieldAnswerCM
                                    {
                                        Id = default(Guid),
                                        EntityId = command.Id,
                                        CompanyId = apqpTemplateDetails.APQPProject.CompanyId,
                                        CustomFieldId = customField.Id,
                                        AnswerValue = answerValue != null ? answerValue.ToString() : null,
                                    }
                                };
                            }
                            else if (customField.Bindingfunction != null)
                            {
                                var answerOptionDataList = await this.lookupManager.GetCustomFieldAnswerOption(customField.Bindingfunction, customField.Id);
                                var answerOptionList = answerOptionDataList?.Select(x => new CustomFieldAnswerOptionCM
                                {
                                    Id = x.Id.Value,
                                    CustomFieldId = x.CustomFieldId,
                                    Value = x.Value
                                }).ToList();
                                customField.AnswerOptions = answerOptionList;
                                customField.CustomFieldAnswers = apqpData.CustomFieldAnswers.Where(x => x.CustomFieldId == customField.Id)?.ToList();
                            }
                            else
                            {
                                customField.CustomFieldAnswers = apqpData.CustomFieldAnswers.Where(x => x.CustomFieldId == customField.Id)?.ToList();
                            }
                        }
                    }
                }
            }

            return apqpTemplateDetails;
        }

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// TSaveResult.
        /// </returns>
        public async Task<GateDataVM> Save(SaveAPQPCommand command)
        {
            if (command.Entity != null)
            {
                var preDefinedFieldsData = this.GetPreDefinedFieldsData(command.Entity);

                APQPData entity;
                if (preDefinedFieldsData != null)
                {
                    if (!string.IsNullOrWhiteSpace(command.Entity.EntityId))
                    {
                        entity = await this.apqpDataRepository.FirstOrDefaultAsync(x => x.APQPId == new Guid(command.Entity.EntityId));

                        if (entity != null)
                        {
                            preDefinedFieldsData.Id = entity.Id;
                            this.mapper.Map(preDefinedFieldsData, entity);
                            this.apqpDataRepository.Update(entity);
                        }
                        else
                        {
                            entity = this.mapper.Map<APQPData>(preDefinedFieldsData);
                            this.apqpDataRepository.Create(entity);
                            var activity = new ActivityVM()
                            {
                                EntityId = entity.Id,
                                ActivityType = Shared.Enum.ActivityType.APQPProjectLaunch,
                                Comment = "Launch APQP Project",

                            };
                            await this.activityManager.SaveActivity(activity);
                        }
                    }

                    await this.apqpDataRepository.SaveAsync();
                }

                var customFieldsData = this.GetCustomFieldsData(command.Entity);

                if (customFieldsData != null && customFieldsData.Any())
                {
                    string customFieldsDataJson = JsonConvert.SerializeObject(
                      customFieldsData,
                      Formatting.None,
                      new JsonSerializerSettings()
                      {
                          ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                      });

                    if (!string.IsNullOrWhiteSpace(command.Entity.EntityId))
                    {
                        await this.repository.SaveAPQPTemplateDeatils(command.Entity.CompanyId, command.Entity.GateId, new Guid(command.Entity.EntityId), customFieldsDataJson);
                    }
                }
            }

            return command.Entity;
        }

        /// <summary>
        /// Saves the apqp project.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// APQPProjectCM.
        /// </returns>
        public async Task<APQPProjectCM> SaveAPQPProject(SaveAPQPProjectCommand command)
        {
            if (command.Entity != null)
            {
                APQPTable.APQP entity = this.mapper.Map<APQPTable.APQP>(command.Entity);
                entity.Status = APQPStatus.InProgress;
                this.repository.Create(entity);
                var activity = new ActivityVM()
                {
                    EntityId = entity.Id,
                    ActivityName = entity.Name,
                    ActivityType = Shared.Enum.ActivityType.APQPProjectLaunch,
                    Comment = "Launch APQP Project",
                };
                await this.activityManager.SaveActivity(activity);
                command.Entity.Id = entity.Id;
                await this.repository.SaveAsync();
                return command.Entity;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Deletes the apqp project.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="referanceId">The referanceId.</param>
        /// <returns>
        /// bool
        /// </returns>
        public async Task<List<DocumentAttachmentCM>> GetDocumentData(Guid id, Guid referanceId)
        {
            var documentAttachments = new List<DocumentAttachmentCM>();
            var attachments = await this.documentAttachmentManager.GetAttachments(id, null, referanceId);

            if (attachments != null && attachments.Any())
            {
                foreach (var attachment in attachments)
                {
                    documentAttachments.Add(new DocumentAttachmentCM
                    {
                        Id = attachment.Id,
                        DocumentTypeId = attachment.DocumentTypeId,
                        Attachments = new List<AttachmentDetailVM> { attachment },
                    });
                }
            }

            return documentAttachments;
        }

        /// <summary>
        /// Gets the apqp document.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Get APQPDocuments</returns>
        public async Task<Page<APQPPartDocumentCM>> GetAPQPDocument(SearchAPQPDocumentCommand command)
        {
            (var items, int totalRecord) = await this.repository.GetAPQPDocuments(command.Id, command.Filter.SearchText, (command.Filter.PagingOption?.Offset ?? 0) + 1, command.Filter.PagingOption?.Limit ?? 1, command.Filter.SortingOption?.SortBy, command.Filter.SortingOption?.SortOrder);

            var data = new Page<APQPPartDocumentCM>()
            {
                Items = items,
                TotalSize = totalRecord,
            };
            return data;
        }

        /// <summary>
        /// Gets the part apqp document data.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<List<DocumentAttachmentCM>> GetPartAPQPDocumentData(Guid id)
        {
            var documentAttachments = new List<DocumentAttachmentCM>();
            var attachments = await this.documentAttachmentManager.GetAttachments(id, null);

            if (attachments != null && attachments.Any())
            {
                foreach (var attachment in attachments)
                {
                    documentAttachments.Add(new DocumentAttachmentCM
                    {
                        Id = attachment.Id,
                        DocumentTypeId = attachment.DocumentTypeId,
                        Attachments = new List<AttachmentDetailVM> { attachment },
                    });
                }
            }

            return documentAttachments;
        }

        private async Task<GateClosureDocumentCM> GetGateClosureDocumentsAsync(Guid id, IQueryable<GateClosureDocument> gateClosureDocumentConfigs, Guid? referanceId)
        {
            if (gateClosureDocumentConfigs != null && gateClosureDocumentConfigs.Any())
            {
                var gateClosureDocumentSetting = new GateClosureDocumentCM();
                var gateClosureSettingId = gateClosureDocumentConfigs.FirstOrDefault().GateClosureSettingId;
                gateClosureDocumentSetting.GateClosureSettingId = gateClosureSettingId;

                List<GateClosureDocument> gateClosureDocuments = this.gateClosureDocumentRepository.GetAll().Where(x => x.GateClosureSettingId == gateClosureSettingId && !x.IsDeleted).ToList();
                gateClosureDocumentSetting.DocumentTypes = gateClosureDocuments.Select(x => x.DocumentTypeId).ToList();
                gateClosureDocumentSetting.DocumentTypeNames = string.Join(", ", gateClosureDocuments.OrderBy(x => x.DocumentType.SortOrder).ThenBy(x => x.DocumentType.Name).Select(x => x.DocumentType.Name).ToList());
                gateClosureDocumentSetting.DocumentAttachments = new List<DocumentAttachmentCM>();

                var attachments = await this.documentAttachmentManager.GetAttachments(id, null, referanceId);
                foreach (var gateClosureDocument in gateClosureDocumentConfigs)
                {
                    List<AttachmentDetailVM> attach = attachments?.Where(a => a.DocumentTypeId == gateClosureDocument.DocumentTypeId).ToList();
                    if (attach != null && attach.Count > 0)
                    {
                        gateClosureDocumentSetting.DocumentAttachments.Add(new DocumentAttachmentCM
                        {
                            Id = gateClosureDocument.Id,
                            DocumentTypeId = gateClosureDocument.DocumentTypeId,
                            DocumentTypeName = gateClosureDocument.DocumentType.Name,
                            Attachments = attach.ToList(),
                        });
                    }
                }

                if (attachments != null && attachments.Any())
                {
                    foreach (var attachment in attachments)
                    {
                        if (!gateClosureDocumentConfigs.Any(x => x.DocumentTypeId == attachment.DocumentTypeId))
                        {
                            gateClosureDocumentSetting.DocumentAttachments.Add(new DocumentAttachmentCM
                            {
                                Id = attachment.Id,
                                DocumentTypeId = attachment.DocumentTypeId,
                                Attachments = new List<AttachmentDetailVM> { attachment }
                            });
                        }
                    }
                }

                return gateClosureDocumentSetting;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Deletes the apqp project.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>bool</returns>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">Record not found.</exception>
        public async Task<bool> DeleteAPQPProject(DeleteAPQPProjectCommand command)
        {
            var entity = await this.repository.GetByIdAsync(command.Id);
            if (entity == null || entity.IsDeleted)
            {
                throw new ValidationException("Record not found.");
            }

            entity.IsDeleted = true;
            await this.repository.SaveAsync();

            return true;
        }

        /// <summary>
        /// Gets the custom fields data.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>List of CustomFieldAnswerCM.</returns>
        private List<CustomFieldAnswerCM> GetCustomFieldsData(GateDataVM entity)
        {
            var customFieldsData = entity.CustomFieldAnswers.Where(x => !x.IsPredefindField);
            var customFieldsAnswers = new List<CustomFieldAnswerCM>();
            if (customFieldsData != null && customFieldsData.Any())
            {
                foreach (var customfield in customFieldsData)
                {
                    if (customfield.AnswerValue != null && customfield.AnswerValue.Any())
                    {
                        foreach (var answer in customfield.AnswerValue)
                        {
                            customFieldsAnswers.Add(new CustomFieldAnswerCM
                            {
                                Id = Guid.NewGuid(),
                                CompanyId = customfield.CompanyId,
                                EntityId = new Guid(customfield.EntityId),
                                CustomFieldId = customfield.CustomFieldId,
                                AnswerValue = answer,
                                Created = DateTime.Now,
                                CreatedBy = "System",
                            });
                        }
                    }
                }
            }

            return customFieldsAnswers;
        }

        /// <summary>
        /// Gets the pre defined fields data.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>APQPDataCM.</returns>
        private APQPDataCM GetPreDefinedFieldsData(GateDataVM entity)
        {
            var preDefinedFieldsData = entity.CustomFieldAnswers.Where(x => x.IsPredefindField);
            APQPDataCM preDefinedFieldsAnswer = null;

            if (preDefinedFieldsData != null && preDefinedFieldsData.Any())
            {
                preDefinedFieldsAnswer = new APQPDataCM();
                preDefinedFieldsAnswer.APQPId = new Guid(preDefinedFieldsData.FirstOrDefault().EntityId);
                preDefinedFieldsAnswer.Created = DateTime.Now;
                preDefinedFieldsAnswer.CreatedBy = "System";

                foreach (var preDefinedField in preDefinedFieldsData)
                {
                    if (preDefinedField?.AnswerValue != null && preDefinedField.AnswerValue.Any())
                    {
                        PropertyInfo propertyInfo = preDefinedFieldsAnswer.GetType().GetProperty(preDefinedField.PredefindFieldName);
                        if (propertyInfo.PropertyType.FullName.Contains("System.Guid"))
                        {
                            propertyInfo.SetValue(preDefinedFieldsAnswer, new Guid(preDefinedField.AnswerValue.FirstOrDefault()), null);
                        }
                        else
                        {
                            propertyInfo.SetValue(preDefinedFieldsAnswer, Convert.ChangeType(preDefinedField.AnswerValue.FirstOrDefault(), propertyInfo.PropertyType), null);
                        }
                    }
                }
            }

            return preDefinedFieldsAnswer;
        }
    }
}
