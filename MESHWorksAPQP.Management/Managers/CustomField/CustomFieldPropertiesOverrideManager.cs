// <copyright file="CustomFieldPropertiesOverrideManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.CustomField
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using AutoMapper;
    using MESHWorksAPQP.Management.Command.CustomField.CustomFieldPropertiesOverride;
    using MESHWorksAPQP.Management.Interface.Managers.CustomField;
    using MESHWorksAPQP.Management.ViewModel.CustomField;
    using MESHWorksAPQP.Model.Models.APQP.Gates;
    using MESHWorksAPQP.Model.Models.CustomField;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.APQPTemplate;
    using MESHWorksAPQP.Repository.Interfaces.CustomField;
    using MESHWorksAPQP.Shared.Enum;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class CustomFieldPropertiesOverrideManager.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Managers.CustomField.ICustomFieldPropertiesOverrideManager" />
    public class CustomFieldPropertiesOverrideManager : ICustomFieldPropertiesOverrideManager
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ICustomFieldPropertiesOverrideRepository repository;

        /// <summary>
        /// The apqp template repository
        /// </summary>
        private readonly IAPQPTemplateRepository apqpTemplateRepository;

        /// <summary>
        /// The custom field repository
        /// </summary>
        private readonly ICustomFieldRepository customFieldRepository;

        /// <summary>
        /// The gate repository
        /// </summary>
        private readonly IGenericRepository<Gate> gateRepository;

        /// <summary>
        /// The user identity
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldPropertiesOverrideManager"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="apqpTemplateRepository">The apqp template repository.</param>
        /// <param name="customFieldRepository">The custom field repository.</param>
        /// <param name="gateRepository">The gate repository.</param>
        /// <param name="userIdentity">The user identity.</param>
        public CustomFieldPropertiesOverrideManager(
            IMapper mapper,
            ICustomFieldPropertiesOverrideRepository repository,
            IAPQPTemplateRepository apqpTemplateRepository,
            ICustomFieldRepository customFieldRepository,
            IGenericRepository<Gate> gateRepository,
            IUserIdentity userIdentity)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.apqpTemplateRepository = apqpTemplateRepository;
            this.customFieldRepository = customFieldRepository;
            this.gateRepository = gateRepository;
            this.userIdentity = userIdentity;
        }

        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// The CustomFieldPropertiesOverrideVM.
        /// </returns>
        public async Task<CustomFieldPropertiesOverrideVM> Get(GetCustomFieldPropertiesOverrideCommand command)
        {
            Guid? companyId = this.userIdentity?.UserInfo?.CompanyId;

            if (command.APQPTemplateId != Guid.Empty && command.CustomFieldId != Guid.Empty && command.GateId != Guid.Empty)
            {
                var entity = await this.repository.GetCustomFieldPropertiesOverride(command.APQPTemplateId, command.GateId, command.CustomFieldId, companyId);

                if (entity != null)
                {
                    return this.mapper.Map<CustomFieldPropertiesOverrideVM>(entity);
                }

                throw new ValidationException("Record not found.");
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// The CustomFieldPropertiesOverrideVM.
        /// </returns>
        public async Task<CustomFieldPropertiesOverrideVM> Save(SaveCustomFieldPropertiesOverrideCommand command)
        {
            if (command.Entity != null && command.Entity.APQPTemplateId != Guid.Empty && command.Entity.CustomFieldId != Guid.Empty)
            {
                Guid? companyId = this.userIdentity.UserInfo.CompanyId;
                var apqpTemplate = await this.apqpTemplateRepository.FirstOrDefaultAsync(x => x.Id == command.Entity.APQPTemplateId && !x.IsDeleted);
                var customField = await this.customFieldRepository.FirstOrDefaultAsync(x => x.Id == command.Entity.CustomFieldId && !x.IsDeleted);
                var gate = await this.gateRepository.FirstOrDefaultAsync(x => x.Id == command.Entity.GateId && x.APQPTemplateId == command.Entity.APQPTemplateId && !x.IsDeleted);

                if (apqpTemplate != null && apqpTemplate.CompanyId == companyId && customField != null && (customField.CompanyId == null || customField.CompanyId == companyId) && gate != null)
                {
                    CustomFieldPropertiesOverride entity;

                    if (command.Id != null && command.Id != Guid.Empty)
                    {
                        entity = await this.repository.FirstOrDefaultAsync(x => x.Id == command.Id.Value && !x.IsDeleted);

                        if (entity == null || entity.APQPTemplateId != command.Entity.APQPTemplateId || entity.CustomFieldId != command.Entity.CustomFieldId || entity.GateId != command.Entity.GateId)
                        {
                            throw new ValidationException("Record not found.");
                        }

                        this.mapper.Map(command.Entity, entity);
                        this.repository.Update(entity);
                    }
                    else
                    {
                        entity = this.mapper.Map<CustomFieldPropertiesOverride>(command.Entity);
                        this.repository.Create(entity);
                    }

                    entity.IsMultiSelect = command.Entity.FieldType == FieldType.DropDown;
                    entity.IsVisibleOnSelection = entity.ParentFeildId != null && entity.ParentFeildId != Guid.Empty && entity.IsVisibleOnSelection;

                    entity.MaxDate = command.Entity.FieldType == FieldType.DatePicker ? entity.MaxDate : null;
                    entity.MinDate = command.Entity.FieldType == FieldType.DatePicker ? entity.MinDate : null;

                    entity.MaxValue = command.Entity.FieldType == FieldType.NumericTextBox ? entity.MaxValue : null;
                    entity.MinValue = command.Entity.FieldType == FieldType.NumericTextBox ? entity.MinValue : null;

                    entity.MaxLength = command.Entity.FieldType == FieldType.TextArea || command.Entity.FieldType == FieldType.TextArea ? entity.MaxLength : null;
                    entity.MinLength = command.Entity.FieldType == FieldType.TextArea || command.Entity.FieldType == FieldType.TextArea ? entity.MinLength : null;

                    if (command.Entity.FieldType == FieldType.CheckBox || command.Entity.FieldType == FieldType.DropDown || command.Entity.FieldType == FieldType.RadioButton)
                    {
                        entity.DefaultValue = null;
                        entity.ValidationRegex = null;
                    }

                    await this.repository.SaveAsync();
                    command.Entity.Id = entity.Id;
                    return command.Entity;
                }

                throw new ValidationException("Invalid Request.");
            }

            throw new ValidationException("Invalid Request.");
        }
    }
}
