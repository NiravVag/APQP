// <copyright file="LookupManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Lookup
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MESHWorksAPQP.Management.Interface.Managers.Lookup;
    using MESHWorksAPQP.Management.Interface.Managers.User;
    using MESHWorksAPQP.Management.ViewModel.CustomField;
    using MESHWorksAPQP.Management.ViewModel.Lookup;
    using MESHWorksAPQP.Model.Models.APQP.Template;
    using MESHWorksAPQP.Model.Models.CustomField;
    using MESHWorksAPQP.Model.Models.Parts;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.CustomField;
    using MESHWorksAPQP.Repository.Interfaces.Setup;
    using MESHWorksAPQP.Shared.Constant;
    using MESHWorksAPQP.Shared.Enum;
    using MESHWorksAPQP.Shared.Interface;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// Class LookupManager.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Managers.Lookup.ILookupManager" />
    public class LookupManager : ILookupManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The commodity repository.
        /// </summary>
        private readonly ICommodityRepository commodityRepository;

        /// <summary>
        /// The material repository.
        /// </summary>
        private readonly IMaterialTypeRepository materialRepository;

        /// <summary>
        /// The material process repository.
        /// </summary>
        private readonly IProcessRepository processRepository;

        /// <summary>
        /// The module type repository.
        /// </summary>
        private readonly IGenericRepository<ModuleType> moduleTypeRepository;

        /// <summary>
        /// The page type repository
        /// </summary>
        private readonly IGenericRepository<PageType> pageTypeRepository;

        /// <summary>
        /// The parte repository
        /// </summary>
        private readonly IGenericRepository<Part> parteRepository;

        /// <summary>
        /// The custom field repository
        /// </summary>
        private readonly ICustomFieldRepository customFieldRepository;

        /// <summary>
        /// The apqp template repository
        /// </summary>
        private readonly IGenericRepository<APQPTemplate> apqpTemplateRepository;

        /// <summary>
        /// The document type repository
        /// </summary>
        private readonly IGenericRepository<DocumentType> documentTypeRepository;

        /// <summary>
        /// The user manager
        /// </summary>
        private readonly IUserManager userManager;

        /// <summary>
        /// The approver fieldAnswerOptionsBindingRepository
        /// </summary>
        private readonly IGenericRepository<FieldAnswerOptionsBinding> fieldAnswerOptionsBindingRepository;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// The role repository
        /// </summary>
        private readonly IGenericRepository<Roles> roleRepository;

        /// <summary>
        /// The designation repository
        /// </summary>
        private readonly IGenericRepository<Designation> designationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupManager"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="commodityRepository">The commodity repository.</param>
        /// <param name="materialRepository">The material repository.</param>
        /// <param name="processRepository">The process repository.</param>
        /// <param name="moduleTypeRepository">The module type repository.</param>
        /// <param name="pageTypeRepository">The page type repository.</param>
        /// <param name="parteRepository">The parte repository.</param>
        /// <param name="customFieldRepository">The custom field repository.</param>
        /// <param name="apqpTemplateRepository">The apqp template repository.</param>
        /// <param name="documentTypeRepository">The document type repository.</param>
        /// <param name="userManager">The userManager</param>
        /// <param name="fieldAnswerOptionsBindingRepository">The fieldAnswerOptionsBindingRepository.</param>
        /// <param name="userIdentity">The userIdentity.</param>
        /// <param name="roleRepository">The role repository.</param>
        /// <param name="designationRepository">The designation repository.</param>
        public LookupManager(
          IMapper mapper,
          ICommodityRepository commodityRepository,
          IMaterialTypeRepository materialRepository,
          IProcessRepository processRepository,
          IGenericRepository<ModuleType> moduleTypeRepository,
          IGenericRepository<PageType> pageTypeRepository,
          IGenericRepository<Part> parteRepository,
          ICustomFieldRepository customFieldRepository,
          IGenericRepository<APQPTemplate> apqpTemplateRepository,
          IGenericRepository<DocumentType> documentTypeRepository,
          IUserManager userManager,
          IGenericRepository<FieldAnswerOptionsBinding> fieldAnswerOptionsBindingRepository,
          IUserIdentity userIdentity,
          IGenericRepository<Roles> roleRepository,
          IGenericRepository<Designation> designationRepository)
        {
            this.mapper = mapper;
            this.commodityRepository = commodityRepository;
            this.materialRepository = materialRepository;
            this.processRepository = processRepository;
            this.moduleTypeRepository = moduleTypeRepository;
            this.pageTypeRepository = pageTypeRepository;
            this.parteRepository = parteRepository;
            this.customFieldRepository = customFieldRepository;
            this.apqpTemplateRepository = apqpTemplateRepository;
            this.documentTypeRepository = documentTypeRepository;
            this.userManager = userManager;
            this.fieldAnswerOptionsBindingRepository = fieldAnswerOptionsBindingRepository;
            this.userIdentity = userIdentity;
            this.roleRepository = roleRepository;
            this.designationRepository = designationRepository;
        }

        /// <summary>
        /// Gets the lookups.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <returns>
        /// List of LookupVM.
        /// </returns>
        public async Task<List<LookupCollectionVM>> GetLookups(List<LookupQuery> filters)
        {
            var lookupCollection = new List<LookupCollectionVM>();
            foreach (var filter in filters)
            {
                lookupCollection.Add(new LookupCollectionVM { Name = filter.LookupType.ToString(), Data = await this.GetLookup(filter) });
            }

            return lookupCollection;
        }

        /// <summary>
        /// Gets the grouped lookup.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Lis of GroupedLookupVM.</returns>
        public async Task<List<GroupedLookupVM>> GetGroupedLookup(LookupQuery filter)
        {
            Guid? companyId = null;
            if (filter.FilterParameters != null)
            {
                if (filter.FilterParameters.ContainsKey("CompanyId") && Guid.TryParse(filter.FilterParameters["CompanyId"], out Guid companyIdValue))
                {
                    companyId = companyIdValue;
                }
            }

            // To do: This is temp logic, Need to get user from portal api then group them by compnayuser type.
            var userList = new Dictionary<Guid, string>
            {
                { new Guid("48ce9901-93ac-4b83-95ee-3b57cde3af05"), "Manager1" },
                { new Guid("ac0357dd-803c-4524-ae53-a56f2ca57211"), "Manager2" },
                { new Guid("3cc62f8b-62d4-4d3b-a16b-8402a7ffc0db"), "User1" },
                { new Guid("28800a3f-d41a-4bd9-9f10-e04d02a3b499"), "User2" },
            };

            var samList = new List<GroupedLookupVM>();

            var managers = new List<LookupVM>();
            var users = new List<LookupVM>();

            foreach (var item in userList)
            {
                if (item.Value.Contains("Manager"))
                {
                    managers.Add(new LookupVM
                    {
                        Id = item.Key,
                        Code = item.Value,
                        Name = item.Value,
                    });
                }
                else
                {
                    users.Add(new LookupVM
                    {
                        Id = item.Key,
                        Code = item.Value,
                        Name = item.Value,
                    });
                }
            }

            samList.Add(new GroupedLookupVM
            {
                GroupBy = "Manager",
                GroupItems = managers,
            });

            samList.Add(new GroupedLookupVM
            {
                GroupBy = "User",
                GroupItems = users,
            });

            return samList;
        }

        /// <summary>
        /// Gets the lookup.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// List of LookupVM.
        /// </returns>
        public async Task<IEnumerable<LookupVM>> GetLookup(LookupQuery filter)
        {
            Guid? companyId = null;
            if (filter.FilterParameters != null)
            {
                if (filter.FilterParameters.ContainsKey("CompanyId") && Guid.TryParse(filter.FilterParameters["CompanyId"], out Guid companyIdValue))
                {
                    companyId = companyIdValue;
                }
            }

            if (companyId == null)
            {
                companyId = this.userIdentity?.UserInfo?.CompanyId ?? default(Guid);
            }

            switch (filter.LookupType)
            {
                case LookupType.Material:
                    return this.materialRepository.GetAll(x => !x.IsDeleted && x.CompanyId == companyId)?.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                case LookupType.Commodity:
                    return this.commodityRepository.GetAll(x => !x.IsDeleted && x.CompanyId == companyId)?.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                case LookupType.Process:
                    return this.processRepository.GetAll(x => !x.IsDeleted && x.CompanyId == companyId)?.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                case LookupType.ModuleType:
                    return this.moduleTypeRepository.GetAll(x => !x.IsDeleted)?.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                case LookupType.PageType:
                    var pageTypeQuery = this.pageTypeRepository.GetAll(x => !x.IsDeleted);
                    return pageTypeQuery?.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                case LookupType.Part:

                    Guid? partId = null;
                    if (filter.FilterParameters != null)
                    {
                        if (filter.FilterParameters.ContainsKey("PartId") && Guid.TryParse(filter.FilterParameters["PartId"], out Guid partIdValue))
                        {
                            partId = partIdValue;
                        }
                    }

                    if (partId != null)
                    {
                        return this.parteRepository.GetAll(x => !x.IsDeleted && x.CompanyId == companyId && x.Id != partId)?.OrderBy(x => x.PartNumber).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                    }
                    else
                    {
                        return this.parteRepository.GetAll(x => !x.IsDeleted && x.CompanyId == companyId).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                    }

                case LookupType.CustomField:

                    Guid? customFieldId = null;
                    if (filter.FilterParameters != null)
                    {
                        if (filter.FilterParameters.ContainsKey("CustomFieldId") && Guid.TryParse(filter.FilterParameters["CustomFieldId"], out Guid customFieldIdValue))
                        {
                            customFieldId = customFieldIdValue;
                        }
                    }

                    if (customFieldId != null)
                    {
                        return this.customFieldRepository.GetAll(x => !x.IsDeleted && x.IsActive && x.CompanyId == companyId && x.Id != customFieldId)?.OrderBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                    }
                    else
                    {
                        return this.customFieldRepository.GetAll(x => !x.IsDeleted && x.IsActive && x.CompanyId == companyId)?.OrderBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                    }

                case LookupType.DocumentType:
                    if (companyId != null)
                    {
                        return this.documentTypeRepository.GetAll(x => !x.IsDeleted && x.CompanyID == companyId)?.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                    }
                    else
                    {
                        return this.documentTypeRepository.GetAll(x => !x.IsDeleted)?.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                    }

                case LookupType.User:
                    if (companyId != null)
                    {
                        var users = await this.userManager.GetUserList(new Commands.User.GetUsersCommand() { CompanyId = (Guid)companyId });
                        return users?.AsQueryable().ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                    }

                    return null;
                case LookupType.CustomFieldType:
                    return this.GetEnumValuesAndDescriptions<FieldType>();
                case LookupType.AnswerOptionType:
                    return this.GetEnumValuesAndDescriptions<AnswerOptionType>();
                case LookupType.APQPTemplate:
                    if (companyId != null)
                    {
                        return this.apqpTemplateRepository.GetAll(x => !x.IsDeleted && x.IsActive && x.CompanyId == companyId)?.OrderByDescending(x => x.Created).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                    }
                    else
                    {
                        return this.apqpTemplateRepository.GetAll(x => !x.IsDeleted && x.IsActive)?.OrderByDescending(x => x.Created).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                    }

                case LookupType.ClosureType:
                    return this.GetEnumValuesAndDescriptions<ClouserType>();
                case LookupType.PredefinedLookupList:
                    return this.fieldAnswerOptionsBindingRepository.GetAll(x => !x.IsDeleted)?.OrderBy(x => x.Bindingfunction).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                case LookupType.Role:
                    if (companyId != null)
                    {
                        return this.roleRepository.GetAll(x => !x.IsDeleted && x.CompanyId == companyId)?.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                    }
                    else
                    {
                        return this.roleRepository.GetAll(x => !x.IsDeleted)?.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                    }

                case LookupType.Designation:
                    if (companyId != null)
                    {
                        return this.designationRepository.GetAll(x => !x.IsDeleted && x.CompanyId == companyId)?.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                    }
                    else
                    {
                        return this.designationRepository.GetAll(x => !x.IsDeleted)?.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                    }

                case LookupType.Discussion:
                    return this.documentTypeRepository.GetAll(x => x.Code == LookupConstant.Discussion && !x.IsDeleted)?.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
                case LookupType.PartDocument:
                    return this.documentTypeRepository.GetAll(x => x.Code == LookupConstant.PartDocument && !x.IsDeleted)?.OrderBy(x => x.SortOrder).ThenBy(x => x.Name).ProjectTo<LookupVM>(this.mapper.ConfigurationProvider);
            }

            return null;
        }

        /// <summary>
        /// Gets the enum values and descriptions.
        /// </summary>
        /// <typeparam name="T">Enum type/</typeparam>
        /// <returns>
        /// LookupVM.
        /// </returns>
        private IEnumerable<LookupVM> GetEnumValuesAndDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("T is not System.Enum");
            }

            var enumValList = new List<LookupVM>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                var fi = e.GetType().GetField(e.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                enumValList.Add(new LookupVM { Id = (int)e, Name = (attributes.Length > 0) ? attributes[0].Description : e.ToString(), Code = e.ToString() });
            }

            return enumValList.OrderBy(x => x.Name);
        }

        /// <summary>
        /// Get Custom Field Answer Option List
        /// </summary>
        /// <param name="bindingfunction">Bindingfunction</param>
        /// <param name="customFieldId">CustomFieldId</param>
        /// <returns>CustomFieldAnswerOptionCM </returns>
        public async Task<List<CustomFieldAnswerOptionVM>> GetCustomFieldAnswerOption(string bindingfunction, Guid customFieldId)
        {
            LookupType lookupTypeData = (LookupType)Enum.Parse(typeof(LookupType), bindingfunction);
            LookupQuery filter = new LookupQuery();
            filter.LookupType = lookupTypeData;
            var lookups = await this.GetLookup(filter);
            var answerOptions = new List<CustomFieldAnswerOptionVM>();
            if (lookups != null && lookups.Any())
            {
                answerOptions = lookups.Select(x => new CustomFieldAnswerOptionVM
                {
                    Id = Guid.Parse(x.Id.ToString()),
                    CustomFieldId = customFieldId,
                    Value = x.Name
                }).ToList();
            }

            return answerOptions;
        }
    }
}
