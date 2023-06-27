// <copyright file="DomainToViewModelMappingProfile.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Mappings
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using MESHWorksAPQP.Management.Helpers;
    using MESHWorksAPQP.Management.ViewModel.Activity;
    using MESHWorksAPQP.Management.ViewModel.APQP;
    using MESHWorksAPQP.Management.ViewModel.APQP.APQPTemplate;
    using MESHWorksAPQP.Management.ViewModel.APQP.Discussion;
    using MESHWorksAPQP.Management.ViewModel.APQP.Gates;
    using MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow;
    using MESHWorksAPQP.Management.ViewModel.CustomField;
    using MESHWorksAPQP.Management.ViewModel.Part;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Management.ViewModel.Setup.DocumentType;
    using MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification;
    using MESHWorksAPQP.Management.ViewModel.Setup.UserManagement;
    using MESHWorksAPQP.Management.ViewModel.User;
    using MESHWorksAPQP.Model.Models.Activity;
    using MESHWorksAPQP.Model.Models.APQP;
    using MESHWorksAPQP.Model.Models.APQP.Gates;
    using MESHWorksAPQP.Model.Models.APQP.Template;
    using MESHWorksAPQP.Model.Models.APQP.WorkFlow;
    using MESHWorksAPQP.Model.Models.CustomField;
    using MESHWorksAPQP.Model.Models.Discussions;
    using MESHWorksAPQP.Model.Models.Documents;
    using MESHWorksAPQP.Model.Models.Parts;
    using MESHWorksAPQP.Model.Models.Role;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.CustomModel;
    using MESHWorksAPQP.Repository.CustomModel.APQP;
    using MESHWorksAPQP.Repository.CustomModel.APQPTemplate;
    using MESHWorksAPQP.Repository.CustomModel.CustomField;
    using MESHWorksAPQP.Repository.CustomModel.Role;
    using MESHWorksAPQP.Shared.Models;

    /// <summary>
    /// Class DomainToViewModelMappingProfile.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainToViewModelMappingProfile"/> class.
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            this.CreateMap<Commodity, LookupVM>();
            this.CreateMap<ModuleType, LookupVM>();

            this.CreateMap<Part, PartVM>();
            this.CreateMap<Part, PartListVM>()
                .ForMember(des => des.CommodityName, opt => opt.MapFrom(src => src.Commodity != null ? src.Commodity.Name : string.Empty))
                .ForMember(des => des.ProcessName, opt => opt.MapFrom(src => src.Process != null ? src.Process.Name : string.Empty))
                .ForMember(des => des.MaterialTypeName, opt => opt.MapFrom(src => src.MaterialType != null ? src.MaterialType.Name : string.Empty));
            this.CreateMap<PartRelation, PartRelationListVM>();

            this.CreateMap<APQPTemplate, APQPTemplateVM>()
                .ForMember(des => des.Gates, opt => opt.MapFrom(src => src.Gates.Where(x => !x.IsDeleted).OrderBy(x => x.SortOrder).ToList()));
            this.CreateMap<APQPTemplateListCM, APQPTemplateListVM>();
            this.CreateMap<Gate, GateVM>()
                .ForMember(des => des.APQPTemplateName, opt => opt.MapFrom(src => src.APQPTemplate.Name))
                .ForMember(des => des.CustomFieldGateMappings, opt => opt.MapFrom(src => src.CustomFieldGateMappings.Where(x => !x.IsDeleted).OrderBy(x => x.Column).ThenBy(x => x.Row)))
                .ForMember(des => des.GateClosureSettings, opt => opt.MapFrom(src => src.GateClosureSetiings.Where(x => !x.IsDeleted)));
            this.CreateMap<CustomField, CustomFieldListVM>();
            this.CreateMap<CustomField, CustomFieldVM>()
                 .ForMember(des => des.AnswerOptions, opt => opt.MapFrom(src => src.AnswerOptions.Where(x => !x.IsDeleted)));
            this.CreateMap<CustomFieldAnswerOption, CustomFieldAnswerOptionVM>();
            this.CreateMap<CustomFieldGateMapping, CustomFieldGateMappingVM>();
            this.CreateMap<CustomFieldListCM, CustomFieldListVM>()
                .ForMember(des => des.FieldTypeName, opt => opt.MapFrom(src => src.FieldType.DescriptionAttribute()));

            this.CreateMap<Commodity, SetupVM>();
            this.CreateMap<Commodity, SetupListVM>();

            this.CreateMap<Process, SetupVM>();
            this.CreateMap<Process, SetupListVM>();

            this.CreateMap<MaterialType, MaterialVM>();
            this.CreateMap<MaterialType, SetupListVM>();

            this.CreateMap<Roles, SetupVM>();
            this.CreateMap<Roles, SetupListVM>();

            this.CreateMap<DocumentType, SetupVM>();
            this.CreateMap<DocumentType, SetupListVM>();

            this.CreateMap<ModuleType, SetupVM>();
            this.CreateMap<ModuleType, SetupListVM>();

            this.CreateMap<EmailNotification, EmailNotificationVM>();
            this.CreateMap<EmailNotification, EmailNotificationListVM>();

            this.CreateMap<PageType, SetupVM>();
            this.CreateMap<PageType, SetupListVM>();

            this.CreateMap<Roles, LookupVM>();
            this.CreateMap<Commodity, LookupVM>();
            this.CreateMap<MaterialType, LookupVM>();
            this.CreateMap<Designation, LookupVM>();

            this.CreateMap<Process, LookupVM>();
            this.CreateMap<CompanyUserType, LookupVM>();
            this.CreateMap<ModuleType, LookupVM>();
            this.CreateMap<PageType, LookupVM>();
            this.CreateMap<Part, LookupVM>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.PartNumber))
                .ForMember(des => des.Code, opt => opt.MapFrom(src => src.PartNumber));
            this.CreateMap<CustomField, LookupVM>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(des => des.Code, opt => opt.MapFrom(src => src.Name));

            this.CreateMap<MESHWorksAPQP.Repository.CustomModel.Gate.GateCM, GateListVM>();

            this.CreateMap<APQP, PartAPQPListVM>()
                .ForMember(des => des.APQPTemplateName, opt => opt.MapFrom(src => src.APQPTemplate.Name));

            this.CreateMap<APQPTemplate, LookupVM>();
            this.CreateMap<GateClosureSetting, GateClosureSettingVM>()
                .ForMember(des => des.ClosureTypeName, opt => opt.MapFrom(src => src.ClouserType.ToString()));
            this.CreateMap<GateClosureApproval, GateClosureApprovalVM>()
                .ForMember(des => des.Approvers, opt => opt.MapFrom(src => src.Approvers.Where(x => !x.IsDeleted)));
            this.CreateMap<GateClosureDocument, GateClosureDocumentVM>();
            this.CreateMap<GateClosureEmail, GateClosureEmailVM>();

            this.CreateMap<GateClosureSetting, GateClosureSettingCM>()
               .ForMember(des => des.ClosureTypeName, opt => opt.MapFrom(src => src.ClouserType));
            this.CreateMap<GateClosureApproval, GateClosureApprovalCM>();
            this.CreateMap<GateClosureDocument, GateClosureDocumentCM>();
            this.CreateMap<GateClosureEmail, GateClosureEmailCM>();

            this.CreateMap<DocumentType, LookupVM>();

            this.CreateMap<GateClosure, GateClouserVM>()
              .ForMember(m => m.GateClosureSettingId, opt => opt.MapFrom(src => src.GateClosureSettingId))
              .ForMember(m => m.Completed, opt => opt.MapFrom(src => src.IsCompleted))
              .ForMember(m => m.ApprovalInProgess, opt => opt.MapFrom(src => !src.IsCompleted));

            this.CreateMap<Document, AttachmentDetailVM>()
              .ForMember(m => m.DocumentTypeId, opt => opt.MapFrom(src => src.DocumentTypeId));

            this.CreateMap<APQPDiscussionCM, APQPDiscussionListVM>();
            this.CreateMap<Discussion, APQPDiscussionVM>();
            this.CreateMap<Approver, ApproverVM>();
            this.CreateMap<Approver, ApproverCM>();

            this.CreateMap<Activity, ActivityVM>();
            this.CreateMap<Activity, ActivityListVM>();

            this.CreateMap<UserVM, LookupVM>()
              .ForMember(m => m.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(m => m.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
              .ForMember(m => m.Code, opt => opt.MapFrom(src => src.UserName));

            this.CreateMap<FieldAnswerOptionsBinding, LookupVM>()
              .ForMember(m => m.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(m => m.Name, opt => opt.MapFrom(src => src.Bindingfunction));

            this.CreateMap<Designation, SetupVM>();
            this.CreateMap<Designation, SetupListVM>();

            this.CreateMap<UserRole, UserRoleVM>();
            this.CreateMap<UserDesignations, UserDesignationsVM>();
            this.CreateMap<UserDesignationsCM, UserDesignationsVM>();
            this.CreateMap<UserManagementListCM, UserManagementListVM>()
                .ForMember(m => m.UserDesignations, opt => opt.MapFrom(src => src.UserDesignations != null ? src.UserDesignations : new List<UserDesignationsCM>()))
                .ForMember(m => m.FirstName, opt => opt.MapFrom(src => src.FirstName != null ? src.FirstName : string.Empty))
                .ForMember(m => m.LastName, opt => opt.MapFrom(src => src.LastName != null ? src.LastName : string.Empty))
                .ForMember(m => m.UserName, opt => opt.MapFrom(src => src.UserName != null ? src.UserName : string.Empty));

            this.CreateMap<CustomFieldPropertiesOverride, CustomFieldPropertiesOverrideVM>();
            this.CreateMap<CustomFieldPropertiesOverrideCM, CustomFieldPropertiesOverrideVM>();
        }
    }
}
