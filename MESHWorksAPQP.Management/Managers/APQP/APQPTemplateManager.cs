// <copyright file="APQPTemplateManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.APQP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Commands.APQP.APQPTemplate;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.APQP;
    using MESHWorksAPQP.Management.ViewModel.APQP.APQPTemplate;
    using MESHWorksAPQP.Model.Models.APQP.Gates;
    using MESHWorksAPQP.Model.Models.APQP.Template;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.APQPTemplate;
    using MESHWorksAPQP.Shared.Interface;
    using APQPTable = MESHWorksAPQP.Model.Models.APQP;

    /// <summary>
    /// class APQPTemplateManager.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Managers.BaseManager{MESHWorksAPQP.Model.Models.APQP.APQP, MESHWorksAPQP.Management.Commands.APQP.SearchAPQPTemplateCommand, MESHWorksAPQP.Management.ViewModel.APQP.APQPListTemplateVM, MESHWorksAPQP.Management.Commands.APQP.GetAPQPTemplateCommand, MESHWorksAPQP.Management.ViewModel.APQP.APQPTemplateVM, MESHWorksAPQP.Management.Commands.APQP.APQPTemplate.SaveAPQPTemplateCommand, MESHWorksAPQP.Management.ViewModel.APQP.APQPTemplateVM, MESHWorksAPQP.Management.ViewModel.APQP.APQPTemplateFilterVM}" />
    /// <seealso cref="MESHWorksAPQP.Management.Managers.BaseManager&lt;MESHWorksAPQP.Model.Models.APQP.APQP, MESHWorksAPQP.Management.Commands.APQP.SearchAPQPCommand, MESHWorksAPQP.Management.ViewModel.APQP.APQPListTemplateVM, MESHWorksAPQP.Management.Commands.APQP.APQPTemplate.GetAPQPTemplateCommand, MESHWorksAPQP.Management.ViewModel.APQP.APQPTemplateVM, MESHWorksAPQP.Management.Commands.APQP.SaveAPQPCommand, MESHWorksAPQP.Management.ViewModel.APQP.APQPTemplateVM, MESHWorksAPQP.Management.ViewModel.APQP.APQPTemplateFilterVM;" />

    /// <seealso cref="MESHWorksAPQP.Management.Interface.Managers.APQP.IAPQPTemplateManager" />
    public class APQPTemplateManager : BaseManager<APQPTemplate, SearchAPQPTemplateCommand, APQPTemplateListVM, GetAPQPTemplateCommand, APQPTemplateVM, SaveAPQPTemplateCommand, APQPTemplateVM, APQPTemplateFilterVM>, IAPQPTemplateManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly IGenericRepository<APQPTable.APQP> repository;

        /// <summary>
        /// The apqp templaterepository.
        /// </summary>
        private readonly IAPQPTemplateRepository apqpTemplaterepository;

        /// <summary>
        /// The gate manager
        /// </summary>
        private readonly IGateManager gateManager;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="APQPTemplateManager" /> class.
        /// </summary>
        /// <param name="mapper">
        /// The mapper.
        /// </param>
        /// <param name="repository">
        /// The repository.
        /// </param>
        /// <param name="apqpTemplaterepository">
        /// The apqp templaterepository.
        /// </param>
        /// <param name="gateManager">
        /// The gate manager.
        /// </param>
        /// <param name="userIdentity">
        /// The userIdentity.
        /// </param>
        public APQPTemplateManager(
            IMapper mapper,
            IGenericRepository<APQPTable.APQP> repository,
            IAPQPTemplateRepository apqpTemplaterepository,
            IGateManager gateManager,
            IUserIdentity userIdentity)
            : base(mapper, apqpTemplaterepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.apqpTemplaterepository = apqpTemplaterepository;
            this.gateManager = gateManager;
            this.userIdentity = userIdentity;
        }

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// Page of TSearchResult.
        /// </returns>
        public async override Task<Page<APQPTemplateListVM>> Search(SearchAPQPTemplateCommand command)
        {
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.Filter.CompanyId ?? default(Guid);

            (var items, int totalRecord) = await this.apqpTemplaterepository.GetAPQPTemplates(companyId, command.Filter.SearchText, command.Filter.IsDeleted ?? false, (command.Filter.PagingOption?.Offset ?? 0) + 1, command.Filter.PagingOption?.Limit ?? 1, command.Filter.SortingOption?.SortBy, command.Filter.SortingOption?.SortOrder);

            return new Page<APQPTemplateListVM>()
            {
                Items = items.AsQueryable().ProjectTo<APQPTemplateListVM>(this.mapper.ConfigurationProvider).ToList(),
                TotalSize = totalRecord,
            };
        }

        /// <summary>
        /// Deletes the specified command.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// bool.
        /// </returns>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">
        /// Record not found.
        /// or
        /// Minimum one template is required to associate with APQP processes.
        /// </exception>
        public async Task<bool> Delete(DeleteAPQPTemplateCommand command)
        {
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.CompanyId ?? default(Guid);

            var templates = this.apqpTemplaterepository.GetAll().Where(x => x.CompanyId == companyId && !x.IsDeleted).ToList();
            if (templates.Count > 1)
            {
                var entity = await this.GetEntity(command.Id);

                if (entity != null && !entity.IsDeleted && entity.CompanyId == companyId)
                {
                    List<APQPTable.APQP> apqps = this.repository.GetAll().Where(x => x.APQPTemplateId == entity.Id && x.CompanyId == entity.CompanyId && !x.IsDeleted).ToList();

                    if (apqps != null && apqps.Any())
                    {
                        throw new ValidationException("This template is already associated with the APQP process. So It can not be deleted.");
                    }

                    entity.IsDeleted = true;
                    await this.repository.SaveAsync();

                    return true;
                }

                throw new ValidationException("Invalid Request.");
            }

            throw new ValidationException("Minimum one template is required to associate with APQP processes.");
        }

        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// APQPTemplateVM.
        /// </returns>
        /// <exception cref="ValidationException">Record not found.</exception>
        public async override Task<APQPTemplateVM> Get(GetAPQPTemplateCommand command)
        {
            var entity = await this.GetEntity(command.Id);
            if (entity == null || entity.IsDeleted)
            {
                throw new ValidationException("Record not found.");
            }

            List<APQPTable.APQP> apqps = this.repository.GetAll().Where(x => x.APQPTemplateId == entity.Id && x.CompanyId == entity.CompanyId && !x.IsDeleted).ToList();
            APQPTemplateVM apqpTemplateVM = this.mapper.Map<APQPTemplateVM>(entity);
            apqpTemplateVM.IsAPQPExist = apqps.Count > 0;
            return apqpTemplateVM;
        }

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// APQPTemplateVM.
        /// </returns>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">
        /// Record not found.
        /// or
        /// Invalid Request.
        /// </exception>
        public async override Task<APQPTemplateVM> Save(SaveAPQPTemplateCommand command)
        {
            if (command.Entity != null)
            {
                if (command.Entity.IsActive && command.Id != null && command.Id.HasValue)
                {
                    var validations = await this.ValidateAPQPTemplate(command.Entity.Id);

                    if (validations != null && validations.Count > 0)
                    {
                        throw new ValidationException(string.Join("\n", validations));
                    }
                }

                APQPTemplate templateEntity;

                if (command.Id != null && command.Id.HasValue)
                {
                    templateEntity = await this.apqpTemplaterepository.FirstOrDefaultAsync(x => x.Id == command.Entity.Id);

                    if (templateEntity == null || templateEntity.IsDeleted)
                    {
                        throw new ValidationException("Record not found.");
                    }

                    this.mapper.Map(command.Entity, templateEntity);
                    this.apqpTemplaterepository.Update(templateEntity);
                }
                else
                {
                    templateEntity = this.mapper.Map<APQPTemplate>(command.Entity);
                    this.apqpTemplaterepository.Create(templateEntity);
                }

                if (templateEntity.Gates != null && templateEntity.Gates.Any())
                {
                    var availableIds = command.Entity.Gates?.Where(x => x.Id != Guid.Empty)?.Select(x => x.Id);
                    templateEntity.Gates.Where(x => !availableIds.Contains(x.Id)).ToList().ForEach(x => x.IsDeleted = true);
                }

                if (command.Entity.Gates != null && command.Entity.Gates.Any())
                {
                    foreach (var item in command.Entity.Gates)
                    {
                        item.APQPTemplateId = templateEntity.Id;

                        bool isGateNameValid = await this.gateManager.CheckGateNameExists(item.Name, command.Entity.Id, item.Id, item.SortOrder, command.Entity);

                        if (isGateNameValid)
                        {
                            Gate gateEntity = null;

                            item.Code = await this.gateManager.SetGetCode(item.Name);

                            if (item.Id != default(Guid))
                            {
                                gateEntity = templateEntity.Gates.FirstOrDefault(x => x.Id == item.Id);
                            }

                            if (gateEntity == null)
                            {
                                gateEntity = this.mapper.Map<Gate>(item);
                                templateEntity.Gates.Add(gateEntity);
                            }
                            else
                            {
                                this.mapper.Map(item, gateEntity);
                                gateEntity.IsDeleted = false;
                            }
                        }
                    }
                }

                await this.repository.SaveAsync();
                command.Entity.Id = templateEntity.Id;

                if (command.Entity.Gates != null && command.Entity.Gates.Count > 0)
                {
                    for (int i = 0; i < command.Entity.Gates.Count; i++)
                    {
                        command.Entity.Gates[i].APQPTemplateId = templateEntity.Id;
                        command.Entity.Gates[i].Id = templateEntity.Gates.FirstOrDefault(x => x.Name == command.Entity.Gates[i].Name).Id;
                    }
                }

                return command.Entity;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Clones the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// Guid.
        /// </returns>
        public async Task<Guid> Clone(CloneAPQPTemplateCommand command)
        {
            Guid cloneAPQPTemplateID = Guid.NewGuid();
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.CompanyId ?? default(Guid);

            await this.apqpTemplaterepository.CloneAPQPTemplate(companyId, command.UserId, command.Id.Value, cloneAPQPTemplateID);

            return cloneAPQPTemplateID;
        }

        /// <summary>
        /// Apqps the template validation.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List of String.
        /// </returns>
        public async Task<List<string>> APQPTemplateValidation(APQPTemplateValidationCommand command)
        {
            return await this.ValidateAPQPTemplate(command.Id);
        }

        /// <summary>
        /// Deactivates the apqp template.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The bool.</returns>
        public async Task<bool> DeactivateAPQPTemplate(DeactivateAPQPTemplateCommand command)
        {
            var entity = await this.GetEntity(command.Id);
            Guid companyId = this.userIdentity?.UserInfo?.CompanyId != null ? (Guid)this.userIdentity.UserInfo.CompanyId : command.CompanyId ?? default(Guid);

            if (entity != null && !entity.IsDeleted && entity.CompanyId == companyId && entity.IsActive)
            {
                List<APQPTable.APQP> apqps = this.repository.GetAll().Where(x => x.APQPTemplateId == entity.Id && x.CompanyId == entity.CompanyId && !x.IsDeleted).ToList();

                if (apqps != null && apqps.Any())
                {
                    throw new ValidationException("This template is already associated with the APQP process. So It can not be deactivated.");
                }

                entity.IsActive = false;
                await this.repository.SaveAsync();

                return true;
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Validates the apqp template.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List of String.</returns>
        private async Task<List<string>> ValidateAPQPTemplate(Guid id)
        {
            var validations = new List<string>();

            var entity = await this.GetEntity(id);

            APQPTemplateVM apqpTemplateVM = this.mapper.Map<APQPTemplateVM>(entity);

            if (!apqpTemplateVM.Gates.Any(x => !x.IsDeleted))
            {
                validations.Add("Minimum one gate is required to activate the APQP template.");
            }

            if (!apqpTemplateVM.Gates.All(x => x.CustomFieldGateMappings.Any(y => !y.IsDeleted)))
            {
                validations.Add("Minimum one custom field is required for each gates to activate the template.");
            }

            // if (!apqpTemplateVM.Gates.All(x => x.GateClosureSettings.Any(y => !y.IsDeleted)))
            // {
            //     validations.Add("Minimum one closure setting is required for each gates to activate the template.");
            // }
            return validations;
        }
    }
}
