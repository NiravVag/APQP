// <copyright file="GateManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.APQP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Commands.APQP;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;
    using MESHWorksAPQP.Management.Interface.Managers.CustomField;
    using MESHWorksAPQP.Management.Interface.Managers.Lookup;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.APQP;
    using MESHWorksAPQP.Management.ViewModel.APQP.Gates;
    using MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow;
    using MESHWorksAPQP.Management.ViewModel.CustomField;
    using MESHWorksAPQP.Management.ViewModel.Lookup;
    using MESHWorksAPQP.Model.Models.APQP.Gates;
    using MESHWorksAPQP.Model.Models.APQP.Template;
    using MESHWorksAPQP.Model.Models.APQP.WorkFlow;
    using MESHWorksAPQP.Model.Models.CustomField;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.APQP;
    using APQPTable = MESHWorksAPQP.Model.Models.APQP;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    ///  class GateManager.
    /// </summary>
    public class GateManager : BaseManager<Gate, SearchGateCommand, GateListVM, GetGateCommand, GateVM, SaveGateCommand, GateVM, FilterVM>, IGateManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IGenericRepository<Gate> repository;

        /// <summary>
        /// The custom field gate mappingrepository.
        /// </summary>
        private readonly IGenericRepository<CustomFieldGateMapping> customFieldGateMappingRepository;

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
        /// The approver repository
        /// </summary>
        private readonly IGenericRepository<Approver> approverRepository;

        /// <summary>
        /// The approver fieldAnswerOptionsBindingRepository
        /// </summary>
        private readonly IGenericRepository<FieldAnswerOptionsBinding> fieldAnswerOptionsBindingRepository;

        /// <summary>
        /// The approver lookupManager
        /// </summary>
        private readonly ILookupManager lookupManager;

        /// <summary>
        /// The apqp repository
        /// </summary>
        private readonly IAPQPRepository apqpRepository;

        /// <summary>
        /// The apqp customFieldRepository
        /// </summary>
        private readonly IGenericRepository<CustomField> customFieldRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GateManager"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="customFieldGateMappingRepository">The customFieldGateMappingRepository.</param>
        /// <param name="gateClosureSettingRepository">The gateClosureSettingRepository.</param>
        /// <param name="gateClosureEmailRepository">The gateClosureEmailRepository.</param>
        /// <param name="gateClosureDocumentRepository">The gateClosureDocumentRepository.</param>
        /// <param name="gateClosureApprovalRepository">The gateClosureApprovalRepository.</param>
        /// <param name="approverRepository">The approverRepository.</param>
        /// <param name="apqpRepository">The apqp repository;.</param>
        /// <param name="fieldAnswerOptionsBindingRepository">The fieldAnswerOptionsBindingRepository.</param>
        /// <param name="lookupManager">The lookupManager.</param>
        /// <param name="customFieldRepository">The customFieldRepository.</param>
        public GateManager(
            IMapper mapper,
            IGenericRepository<Gate> repository,
            IGenericRepository<CustomFieldGateMapping> customFieldGateMappingRepository,
            IGenericRepository<GateClosureSetting> gateClosureSettingRepository,
            IGenericRepository<GateClosureEmail> gateClosureEmailRepository,
            IGenericRepository<GateClosureDocument> gateClosureDocumentRepository,
            IGenericRepository<GateClosureApproval> gateClosureApprovalRepository,
            IGenericRepository<Approver> approverRepository,
            IGenericRepository<FieldAnswerOptionsBinding> fieldAnswerOptionsBindingRepository,
            ILookupManager lookupManager,
            IAPQPRepository apqpRepository,
            IGenericRepository<CustomField> customFieldRepository)
             : base(mapper, repository)
        {
            this.repository = repository;
            this.customFieldGateMappingRepository = customFieldGateMappingRepository;
            this.mapper = mapper;
            this.gateClosureSettingRepository = gateClosureSettingRepository;
            this.gateClosureEmailRepository = gateClosureEmailRepository;
            this.gateClosureDocumentRepository = gateClosureDocumentRepository;
            this.gateClosureApprovalRepository = gateClosureApprovalRepository;
            this.approverRepository = approverRepository;
            this.fieldAnswerOptionsBindingRepository = fieldAnswerOptionsBindingRepository;
            this.lookupManager = lookupManager;
            this.apqpRepository = apqpRepository;
            this.customFieldRepository = customFieldRepository;
        }

        /// <summary>
        /// Deletes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// bool.
        /// </returns>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">Invalid Request.</exception>
        public async Task<bool> Delete(DeleteGateCommand command)
        {
            var entity = await this.GetEntity(command.Id);

            if (entity != null && !entity.IsDeleted && !entity.APQPTemplate.IsDeleted && entity.APQPTemplateId == command.APQPTemplateId)
            {
                if (entity.APQPTemplate.IsActive)
                {
                    List<APQPTable.APQP> apqps;
                    if (entity.APQPTemplate.CompanyId.HasValue)
                    {
                        apqps = this.apqpRepository.GetAll().Where(x => x.APQPTemplateId == command.APQPTemplateId && x.CompanyId == entity.APQPTemplate.CompanyId.Value && !x.IsDeleted).ToList();
                    }
                    else
                    {
                        apqps = this.apqpRepository.GetAll().Where(x => x.APQPTemplateId == command.APQPTemplateId && x.CompanyId == null && !x.IsDeleted).ToList();
                    }

                    if (apqps != null && apqps.Any())
                    {
                        throw new ValidationException($"This template is already associated with the APQP process. So Gate - {entity.Name} can not be deleted.");
                    }
                }

                entity.IsDeleted = true;
                await this.repository.SaveAsync();

                return true;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// TGetResult.
        /// </returns>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">Record not found.</exception>
        public override async Task<GateVM> Get(GetGateCommand command)
        {
            var entity = await this.GetEntity(command.Id);
            if (entity == null || entity.IsDeleted)
            {
                throw new ValidationException("Record not found.");
            }

            GateVM gate = this.mapper.Map<GateVM>(entity);

            if (gate.GateClosureSettings != null && gate.GateClosureSettings.Any())
            {
                foreach (var item in gate.GateClosureSettings)
                {
                    if (item.ClouserType == Shared.Enum.ClouserType.Approval)
                    {
                        GateClosureApproval gateClosureApproval = await this.gateClosureApprovalRepository.FirstOrDefaultAsync(x => x.GateClosureSettingId == item.Id && !x.IsDeleted);
                        item.GateClosureApproval = this.mapper.Map<GateClosureApprovalVM>(gateClosureApproval);
                    }
                    else if (item.ClouserType == Shared.Enum.ClouserType.Document)
                    {
                        List<GateClosureDocument> gateClosureDocuments = this.gateClosureDocumentRepository.GetAll().Where(x => x.GateClosureSettingId == item.Id && !x.IsDeleted).ToList();
                        item.GateClosureDocument = new GateClosureDocumentVM()
                        {
                            GateClosureSettingId = item.Id,
                            DocumentTypes = gateClosureDocuments.Select(x => x.DocumentTypeId).ToList(),
                            DocumentTypeNames = string.Join(", ", gateClosureDocuments.OrderBy(x => x.DocumentType.SortOrder).ThenBy(x => x.DocumentType.Name).Select(x => x.DocumentType.Name).ToList())
                        };
                    }
                    else if (item.ClouserType == Shared.Enum.ClouserType.Email)
                    {
                        GateClosureEmail gateClosureEmail = await this.gateClosureEmailRepository.FirstOrDefaultAsync(x => x.GateClosureSettingId == item.Id && !x.IsDeleted);
                        item.GateClosureEmail = this.mapper.Map<GateClosureEmailVM>(gateClosureEmail);
                    }
                }
            }

            if (gate.CustomFieldGateMappings != null && gate.CustomFieldGateMappings.Any())
            {
                foreach (var item in gate.CustomFieldGateMappings)
                {
                    var customField = await this.customFieldRepository.GetByIdAsync(item.CustomFieldId);
                    var fieldAnswerOptionsBindingEntity = await this.fieldAnswerOptionsBindingRepository.FirstOrDefaultAsync(x => x.Id == customField.FieldAnswerOptionsBindingId);
                    item.CustomField.Bindingfunction = fieldAnswerOptionsBindingEntity?.Bindingfunction;
                    if (item.CustomField.Bindingfunction != null)
                    {
                        item.CustomField.AnswerOptions = await this.lookupManager.GetCustomFieldAnswerOption(item.CustomField.Bindingfunction, item.CustomFieldId);
                    }
                }
            }

            return gate;
        }

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// TSaveResult.
        /// </returns>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">
        /// Record not found.
        /// or
        /// Invalid Request.
        /// </exception>
        public override async Task<GateVM> Save(SaveGateCommand command)
        {
            if (command.Entity != null && command.Entity.APQPTemplateId != default(Guid))
            {
                bool isGateNameValid = await this.CheckGateNameExists(command.Entity.Name, command.Entity.APQPTemplateId, command.Id, command.Entity.SortOrder);
                if (isGateNameValid)
                {
                    Gate entity;

                    command.Entity.Code = await this.SetGetCode(command.Entity.Name);

                    if (command.Id != null && command.Id.HasValue)
                    {
                        entity = await this.GetEntity(command.Id.Value);

                        if (entity == null || entity.IsDeleted)
                        {
                            throw new ValidationException("Record not found.");
                        }

                        this.mapper.Map(command.Entity, entity);
                        this.repository.Update(entity);
                    }
                    else
                    {
                        entity = this.mapper.Map<Gate>(command.Entity);
                        this.repository.Create(entity);
                    }

                    // CustomFieldGateMappings
                    if (entity.CustomFieldGateMappings != null && entity.CustomFieldGateMappings.Any())
                    {
                        var availableIds = command.Entity.CustomFieldGateMappings?.Where(x => x.Id != Guid.Empty)?.Select(x => x.Id);
                        entity.CustomFieldGateMappings.Where(x => !availableIds.Contains(x.Id)).ToList().ForEach(x => x.IsDeleted = true);
                    }

                    if (command.Entity.CustomFieldGateMappings != null && command.Entity.CustomFieldGateMappings.Any())
                    {
                        foreach (var item in command.Entity.CustomFieldGateMappings)
                        {
                            CustomFieldGateMapping customFieldGateMapping = null;
                            if (item.Id != default(Guid))
                            {
                                customFieldGateMapping = await this.customFieldGateMappingRepository.FirstOrDefaultAsync(x => x.Id == item.Id && !x.IsDeleted);
                            }

                            if (customFieldGateMapping == null)
                            {
                                customFieldGateMapping = this.mapper.Map<CustomFieldGateMapping>(item);
                                entity.CustomFieldGateMappings.Add(customFieldGateMapping);
                            }
                            else
                            {
                                this.mapper.Map(item, customFieldGateMapping);
                                customFieldGateMapping.IsDeleted = false;
                            }
                        }
                    }

                    // GateClosureSettings
                    if (entity.GateClosureSetiings != null && entity.GateClosureSetiings.Any())
                    {
                        var availableIds = command.Entity.GateClosureSettings?.Where(x => x.Id != Guid.Empty)?.Select(x => x.Id);
                        entity.GateClosureSetiings.Where(x => !availableIds.Contains(x.Id)).ToList().ForEach(x => x.IsDeleted = true);
                    }

                    if (command.Entity.GateClosureSettings != null && command.Entity.GateClosureSettings.Any())
                    {
                        int totalClosureApprovals = command.Entity.GateClosureSettings.Where(x => x.ClouserType == Shared.Enum.ClouserType.Approval && !x.IsDeleted).ToList().Count;
                        if (totalClosureApprovals > 1)
                        {
                            throw new ValidationException("Only one closure setting is allowed for the Closure Approval Setting.");
                        }

                        int totalClosureDocuments = command.Entity.GateClosureSettings.Where(x => x.ClouserType == Shared.Enum.ClouserType.Document && !x.IsDeleted).ToList().Count;
                        if (totalClosureDocuments > 1)
                        {
                            throw new ValidationException("Only one closure setting is allowed for the Closure Document Setting.");
                        }

                        int totalClosureEmails = command.Entity.GateClosureSettings.Where(x => x.ClouserType == Shared.Enum.ClouserType.Email && !x.IsDeleted).ToList().Count;
                        if (totalClosureEmails > 1)
                        {
                            throw new ValidationException("Only one closure setting is allowed for the Closure Email Setting.");
                        }

                        foreach (var item in command.Entity.GateClosureSettings)
                        {
                            GateClosureSetting gateClosureSetting = null;
                            if (item.Id != default(Guid))
                            {
                                gateClosureSetting = await this.gateClosureSettingRepository.FirstOrDefaultAsync(x => x.Id == item.Id);
                            }

                            if (gateClosureSetting == null)
                            {
                                gateClosureSetting = this.mapper.Map<GateClosureSetting>(item);
                                entity.GateClosureSetiings.Add(gateClosureSetting);
                                this.gateClosureSettingRepository.Create(gateClosureSetting);
                            }
                            else
                            {
                                this.mapper.Map(item, gateClosureSetting);
                                gateClosureSetting.IsDeleted = false;
                                this.gateClosureSettingRepository.Update(gateClosureSetting);
                            }

                            item.Id = gateClosureSetting.Id;

                            if (gateClosureSetting.ClouserType == Shared.Enum.ClouserType.Email && item.GateClosureEmail != null)
                            {
                                if (string.IsNullOrEmpty(item.GateClosureEmail.To) || string.IsNullOrEmpty(item.GateClosureEmail.Subject) || string.IsNullOrEmpty(item.GateClosureEmail.Message))
                                {
                                    throw new ValidationException("Fill all required fields for Gate Colosure Email.");
                                }

                                GateClosureEmail gateClosureEmail = null;
                                if (item.GateClosureEmail.Id != default(Guid))
                                {
                                    gateClosureEmail = await this.gateClosureEmailRepository.FirstOrDefaultAsync(x => x.Id == item.GateClosureEmail.Id && !x.IsDeleted);
                                }

                                if (gateClosureEmail == null)
                                {
                                    gateClosureEmail = this.mapper.Map<GateClosureEmail>(item.GateClosureEmail);
                                    gateClosureEmail.GateClosureSettingId = item.Id;
                                    this.gateClosureEmailRepository.Create(gateClosureEmail);
                                }
                                else
                                {
                                    this.mapper.Map(item.GateClosureEmail, gateClosureEmail);
                                    gateClosureEmail.GateClosureSettingId = item.Id;
                                    gateClosureEmail.IsDeleted = false;
                                    this.gateClosureEmailRepository.Update(gateClosureEmail);
                                }

                                await this.gateClosureEmailRepository.SaveAsync();
                            }
                            else if (gateClosureSetting.ClouserType == Shared.Enum.ClouserType.Document && item.GateClosureDocument != null)
                            {
                                List<GateClosureDocument> gateClosureDocuments = this.gateClosureDocumentRepository.GetAll().Where(x => x.GateClosureSettingId == gateClosureSetting.Id && !x.IsDeleted).ToList();

                                if (gateClosureDocuments != null && gateClosureDocuments.Any())
                                {
                                    var availableIds = item.GateClosureDocument.DocumentTypes?.Where(x => x != default(Guid)).Select(x => x);
                                    gateClosureDocuments.Where(x => !availableIds.Contains(x.Id)).ToList().ForEach(x => x.IsDeleted = true);
                                }

                                if (item.GateClosureDocument.DocumentTypes != null && item.GateClosureDocument.DocumentTypes.Any())
                                {
                                    foreach (var documentType in item.GateClosureDocument.DocumentTypes)
                                    {
                                        var entityClosureDocument = gateClosureDocuments.FirstOrDefault(x => x.DocumentTypeId == documentType);
                                        if (entityClosureDocument == null)
                                        {
                                            entityClosureDocument = new GateClosureDocument()
                                            {
                                                GateClosureSettingId = gateClosureSetting.Id,
                                                DocumentTypeId = documentType
                                            };

                                            gateClosureDocuments.Add(entityClosureDocument);
                                            this.gateClosureDocumentRepository.Create(entityClosureDocument);
                                        }
                                        else
                                        {
                                            entityClosureDocument.IsDeleted = false;
                                            this.gateClosureDocumentRepository.Update(entityClosureDocument);
                                        }

                                        await this.gateClosureDocumentRepository.SaveAsync();
                                    }
                                }
                            }
                            else if (gateClosureSetting.ClouserType == Shared.Enum.ClouserType.Approval && item.GateClosureApproval != null)
                            {
                                GateClosureApproval gateClosureApproval = null;
                                if (item.GateClosureApproval.Id != default(Guid))
                                {
                                    gateClosureApproval = await this.gateClosureApprovalRepository.FirstOrDefaultAsync(x => x.Id == item.GateClosureApproval.Id && !x.IsDeleted);
                                }

                                if (gateClosureApproval == null)
                                {
                                    gateClosureApproval = this.mapper.Map<GateClosureApproval>(item.GateClosureApproval);
                                    gateClosureApproval.GateClosureSettingId = item.Id;
                                    this.gateClosureApprovalRepository.Create(gateClosureApproval);
                                }
                                else
                                {
                                    this.mapper.Map(item.GateClosureApproval, gateClosureApproval);
                                    gateClosureApproval.GateClosureSettingId = item.Id;
                                    gateClosureApproval.IsDeleted = false;
                                    this.gateClosureApprovalRepository.Update(gateClosureApproval);
                                }

                                if (item.GateClosureApproval.Approvers != null && item.GateClosureApproval.Approvers.Any())
                                {
                                    if (gateClosureApproval.Approvers != null && gateClosureApproval.Approvers.Any())
                                    {
                                        gateClosureApproval.Approvers.ToList().ForEach(x => x.IsDeleted = true);
                                    }

                                    foreach (var approver in item.GateClosureApproval.Approvers)
                                    {
                                        Approver approverEntity = null;
                                        if (approver != null && approver.Id != null && approver.Id.HasValue && approver.Id != default(Guid))
                                        {
                                            approverEntity = gateClosureApproval.Approvers?.FirstOrDefault(x => x.Id == approver.Id);
                                        }

                                        if (approverEntity == null)
                                        {
                                            approverEntity = this.mapper.Map<Approver>(approver);
                                            gateClosureApproval.Approvers.Add(approverEntity);
                                        }
                                        else
                                        {
                                            this.mapper.Map<Approver>(approverEntity);
                                            approverEntity.UserId = approver.UserId;
                                            approverEntity.IsDeleted = false;
                                            approverEntity.RequiredApprover = approver.RequiredApprover;
                                            gateClosureApproval.Approvers.Add(approverEntity);
                                        }
                                    }
                                }

                                await this.gateClosureApprovalRepository.SaveAsync();

                                // var approvers = this.approverRepository.GetAll(x => x.GateClosureApprovalId == item.GateClosureApproval.Id && !x.IsDeleted)?.ToList();
                                // if (approvers != null && approvers.Any())
                                // {
                                //     approvers.ForEach(x => x.IsDeleted = true);
                                // }
                                // if (item.GateClosureApproval.Approvers != null && item.GateClosureApproval.Approvers.Any())
                                // {
                                //     foreach (var approver in item.GateClosureApproval.Approvers)
                                //     {
                                //         Approver approverEntity = null;
                                //         if (approver != null && approver.Id != null && approver.Id.HasValue)
                                //         {
                                //             approverEntity = await this.approverRepository.FirstOrDefaultAsync(x => x.Id == approver.Id && !x.IsDeleted);
                                //         }
                                //         if (approverEntity == null)
                                //         {
                                //             approverEntity = this.mapper.Map<Approver>(approver);
                                //             this.approverRepository.Create(approverEntity);
                                //         }
                                //         else
                                //         {
                                //             approverEntity = this.mapper.Map<Approver>(approver);
                                //             approverEntity.IsDeleted = false;
                                //             this.approverRepository.Update(approverEntity);
                                //         }
                                //     }
                                //     await this.approverRepository.SaveAsync();
                                // }
                            }
                        }

                        await this.gateClosureSettingRepository.SaveAsync();
                    }

                    await this.repository.SaveAsync();
                    command.Entity.Id = entity.Id;
                    return command.Entity;
                }
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Checks the gate name exists.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="templateId">The template identifier.</param>
        /// <param name="gateId">The gate identifier.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="apqpTemplate">The apqp template.</param>
        /// <returns>bool.</returns>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">Gate name {gate.Name} already exists for this APQP template.</exception>
        public async Task<bool> CheckGateNameExists(string name, Guid templateId, Guid? gateId, int sortOrder, APQPTemplateVM apqpTemplate = null)
        {
            Gate gate;

            if (apqpTemplate == null)
            {
                gate = await this.repository.FirstOrDefaultAsync(x => x.Name == name && x.APQPTemplateId == templateId && !x.IsDeleted);
            }
            else
            {
                GateVM gateVM = apqpTemplate.Gates.FirstOrDefault(x => x.Name == name && x.APQPTemplateId == templateId && !x.IsDeleted);
                gate = this.mapper.Map<Gate>(gateVM);
            }

            if (gate == null || (gate != null && gateId != null && gate.Id == gateId && gate.SortOrder == sortOrder))
            {
                return true;
            }

            throw new ValidationException($"Gate name {gate.Name} already exists for this APQP template.");
        }

        /// <summary>
        /// Sets the get code.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// string.
        /// </returns>
        public async Task<string> SetGetCode(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return Regex.Replace(name, @"[^0-9a-zA-Z]+", string.Empty);
            }

            return null;
        }
    }
}
