// <copyright file="CustomFieldManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.CustomField
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Commands.CustomField;
    using MESHWorksAPQP.Management.Interface.Managers.CustomField;
    using MESHWorksAPQP.Management.Interface.Managers.Lookup;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.CustomField;
    using MESHWorksAPQP.Model.Models.CustomField;
    using MESHWorksAPQP.Repository.CustomModel.CustomField;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.CustomField;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class CustomFieldManager.
    /// </summary>
    public class CustomFieldManager : BaseManager<CustomField, SearchCustomFieldCommand, CustomFieldListVM, GetCustomFieldCommand, CustomFieldVM, SaveCustomFieldCommand, CustomFieldVM, CustomFieldFilterVM>, ICustomFieldManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ICustomFieldRepository repository;

        /// <summary>
        /// The field answer options binding repository.
        /// </summary>
        private readonly IGenericRepository<FieldAnswerOptionsBinding> fieldAnswerOptionsBindingRepository;

        /// <summary>
        /// The field answer options binding lookupManager.
        /// </summary>
        private readonly ILookupManager lookupManager;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFieldManager"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="fieldAnswerOptionsBindingRepository">The fieldAnswerOptionsBindingRepository.</param>
        /// <param name = "lookupManager" > The lookupManager.</param>
        /// <param name = "customFieldRepository" > The customFieldRepository.</param>
        /// <param name = "userIdentity" > The userIdentity.</param>
        public CustomFieldManager(
           IMapper mapper,
           ICustomFieldRepository repository,
           IGenericRepository<FieldAnswerOptionsBinding> fieldAnswerOptionsBindingRepository,
           ILookupManager lookupManager,
           IUserIdentity userIdentity)
            : base(mapper, repository)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.fieldAnswerOptionsBindingRepository = fieldAnswerOptionsBindingRepository;
            this.lookupManager = lookupManager;
            this.userIdentity = userIdentity;
        }

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// Page of QuoteListVM.
        /// </returns>
        public async override Task<Page<CustomFieldListVM>> Search(SearchCustomFieldCommand command)
        {
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.Filter.CompanyId;

            (var items, int totalRecord) = await this.repository.GetCustomFields(companyId, command.Filter.SearchText, command.Filter.IsDeleted ?? false, (command.Filter.PagingOption?.Offset ?? 0) + 1, command.Filter.PagingOption?.Limit ?? 1, command.Filter.SortingOption?.SortBy, command.Filter.SortingOption?.SortOrder);

            return new Page<CustomFieldListVM>()
            {
                Items = items.AsQueryable().ProjectTo<CustomFieldListVM>(this.mapper.ConfigurationProvider).ToList(),
                TotalSize = totalRecord,
            };
        }

        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// CustomFieldVM.
        /// </returns>
        /// <exception cref="ValidationException">Invalid Request.</exception>
        public override async Task<CustomFieldVM> Get(GetCustomFieldCommand command)
        {
            CustomField entity = await this.GetEntity(command.Id);

            if (entity != null && command.Id != Guid.Empty && entity.Id == command.Id)
            {
                var fieldAnswerOptionsBindingEntity = await this.fieldAnswerOptionsBindingRepository.FirstOrDefaultAsync(x => x.Id == entity.FieldAnswerOptionsBindingId);
                var customField = this.mapper.Map<CustomFieldVM>(entity);
                customField.Bindingfunction = fieldAnswerOptionsBindingEntity?.Bindingfunction;
                if (customField.Bindingfunction != null)
                {
                    customField.AnswerOptions = await this.lookupManager.GetCustomFieldAnswerOption(customField.Bindingfunction, customField.Id);
                }

                return customField;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>CustomFieldVM.</returns>
        /// <exception cref="ValidationException">Invalid CustomField.</exception>
        /// <exception cref="ValidationException">Invalid Request.</exception>
        /// <exception cref="ValidationException">Record not found.</exception>
        public override async Task<CustomFieldVM> Save(SaveCustomFieldCommand command)
        {
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.Entity.CompanyId;

            if (command.Entity != null && companyId != Guid.Empty)
            {
                bool isCustomFieldValid = await this.CheckCustomFieldNameExists(command.Entity.Name, companyId, command.Id);

                if (isCustomFieldValid)
                {
                    CustomField entity;
                    Guid? bindingfunctionId;
                    if (command.Entity.Bindingfunction != null)
                    {
                        var bindingfunction = await this.fieldAnswerOptionsBindingRepository.FirstOrDefaultAsync(x => x.Bindingfunction == command.Entity.Bindingfunction);
                        bindingfunctionId = bindingfunction.Id;
                    }
                    else
                    {
                        bindingfunctionId = null;
                    }

                    if (command.Id != null && command.Id.HasValue)
                    {
                        entity = await this.GetEntity(command.Id.Value);

                        if (entity == null || entity.IsDeleted || entity.CompanyId != companyId)
                        {
                            throw new ValidationException("Record not found.");
                        }

                        this.mapper.Map(command.Entity, entity);
                        entity.FieldAnswerOptionsBindingId = bindingfunctionId;
                        this.repository.Update(entity);
                        await this.repository.SaveAsync();
                    }
                    else
                    {
                        entity = this.mapper.Map<CustomField>(command.Entity);
                        entity.FieldAnswerOptionsBindingId = bindingfunctionId;
                        this.repository.Create(entity);
                        await this.repository.SaveAsync();
                    }

                    if (bindingfunctionId == null)
                    {
                        if (entity.AnswerOptions != null && entity.AnswerOptions.Any())
                        {
                            var availableIds = command.Entity.AnswerOptions?.Where(x => x.Id != Guid.Empty)?.Select(x => x.Id);
                            entity.AnswerOptions.Where(x => !availableIds.Contains(x.Id)).ToList().ForEach(x => x.IsDeleted = true);
                        }

                        if (command.Entity.AnswerOptions != null && command.Entity.AnswerOptions.Any())
                        {
                            foreach (var item in command.Entity.AnswerOptions)
                            {
                                CustomFieldAnswerOption entityAnswerOption = null;
                                if (command.Entity.FieldType == MESHWorksAPQP.Shared.Enum.FieldType.NumericTextBox ||
                                    command.Entity.FieldType == MESHWorksAPQP.Shared.Enum.FieldType.TextArea ||
                                    command.Entity.FieldType == MESHWorksAPQP.Shared.Enum.FieldType.DatePicker ||
                                    command.Entity.FieldType == MESHWorksAPQP.Shared.Enum.FieldType.TextBox)
                                {
                                    item.IsDefault = true;
                                }

                                if (item.Id != null && item.Id.HasValue && item.Id != default(Guid))
                                {
                                    entityAnswerOption = entity.AnswerOptions?.FirstOrDefault(x => x.Id == item.Id);
                                }

                                if (entityAnswerOption == null)
                                {
                                    if (item.Value != null)
                                    {
                                        entityAnswerOption = this.mapper.Map<CustomFieldAnswerOption>(item);
                                        entity.AnswerOptions.Add(entityAnswerOption);
                                    }
                                }
                                else
                                {
                                    this.mapper.Map(item, entityAnswerOption);
                                    entityAnswerOption.CustomFieldId = entity.Id;
                                    entityAnswerOption.IsDeleted = false;
                                }
                            }
                        }
                    }

                    await this.repository.SaveAsync();
                    await this.fieldAnswerOptionsBindingRepository.SaveAsync();
                    command.Entity.Id = entity.Id;
                    return command.Entity;
                }
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// bool.
        /// </returns>
        /// <exception cref="ValidationException">Invalid Location.</exception>
        public async Task<bool> Delete(DeleteCustomFieldCommand command)
        {
            CustomField entity = await this.GetEntity(command.Id);
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.CompanyId ?? default(Guid);

            if (entity != null && !entity.IsDeleted && entity.CompanyId == companyId)
            {
                entity.IsDeleted = true;
                await this.repository.SaveAsync();
                return true;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Gets the custom fields.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// List of CustomFieldCM.
        /// </returns>
        public async Task<IList<CustomFieldCM>> GetCustomFields(GetActiveCustomFieldCommand command)
        {
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.CompanyId ?? default(Guid);

            var customFieldsData = await this.repository.GetActiveCustomFields(companyId, command.APQPTemplateId);
            foreach (var customField in customFieldsData)
            {
                if (customField.FieldAnswerOptionsBindingId != null)
                {
                    var fieldAnswerOptionsBindingEntity = await this.fieldAnswerOptionsBindingRepository.FirstOrDefaultAsync(x => x.Id == customField.FieldAnswerOptionsBindingId);
                    customField.Bindingfunction = fieldAnswerOptionsBindingEntity?.Bindingfunction;
                    if (customField.Bindingfunction != null)
                    {
                        var answerOptionDataList = await this.lookupManager.GetCustomFieldAnswerOption(customField.Bindingfunction, customField.Id);
                        var answerOptionList = answerOptionDataList?.Select(x => new FormCustomFieldAnswerOptionCM
                        {
                            Id = x.Id.Value,
                            CustomFieldId = x.CustomFieldId,
                            Value = x.Value
                        }).ToList();
                        customField.AnswerOptions = answerOptionList;
                    }
                }
            }

            return customFieldsData;
        }

        /// <summary>
        /// Checks the custom field name exists.
        /// </summary>
        /// <param name="customFieldName">Name of the custom field.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="customFieldId">The custom field identifier.</param>
        /// <returns>bool.</returns>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">Custom Field name {customField.Name} already exists.</exception>
        private async Task<bool> CheckCustomFieldNameExists(string customFieldName, Guid companyId, Guid? customFieldId)
        {
            var customField = await this.repository.FirstOrDefaultAsync(x => x.Name == customFieldName && !x.IsDeleted && x.CompanyId == companyId);
            if (customField == null || (customField != null && customFieldId != null && customField.Id == customFieldId))
            {
                return true;
            }

            throw new ValidationException($"Custom Field name {customField.Name} already exists.");
        }
    }
}
