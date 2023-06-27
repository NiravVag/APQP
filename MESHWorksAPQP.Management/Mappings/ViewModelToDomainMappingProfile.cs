// <copyright file="ViewModelToDomainMappingProfile.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Mappings
{
    using AutoMapper;
    using MESHWorksAPQP.Management.ViewModel.Activity;
    using MESHWorksAPQP.Management.ViewModel.APQP;
    using MESHWorksAPQP.Management.ViewModel.APQP.Discussion;
    using MESHWorksAPQP.Management.ViewModel.APQP.Gates;
    using MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow;
    using MESHWorksAPQP.Management.ViewModel.CustomField;
    using MESHWorksAPQP.Management.ViewModel.Part;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Management.ViewModel.Setup.DocumentType;
    using MESHWorksAPQP.Management.ViewModel.Setup.EmailNotification;
    using MESHWorksAPQP.Management.ViewModel.Setup.UserManagement;
    using MESHWorksAPQP.Model.Models.Activity;
    using MESHWorksAPQP.Model.Models.APQP;
    using MESHWorksAPQP.Model.Models.APQP.Gates;
    using MESHWorksAPQP.Model.Models.APQP.Template;
    using MESHWorksAPQP.Model.Models.APQP.WorkFlow;
    using MESHWorksAPQP.Model.Models.CustomField;
    using MESHWorksAPQP.Model.Models.Discussions;
    using MESHWorksAPQP.Model.Models.Parts;
    using MESHWorksAPQP.Model.Models.Role;
    using MESHWorksAPQP.Model.Models.Setup;
    using MESHWorksAPQP.Repository.CustomModel.APQP;

    /// <summary>
    /// Class ViewModelToDomainMappingProfile.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ViewModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelToDomainMappingProfile"/> class.
        /// </summary>
        public ViewModelToDomainMappingProfile()
        {
            this.CreateMap<PartVM, Part>();
            this.CreateMap<SetupVM, ModuleType>();
            this.CreateMap<PageTypeVM, PageType>();
            this.CreateMap<SetupVM, Process>();
            this.CreateMap<SetupVM, Commodity>();
            this.CreateMap<MaterialVM, MaterialType>();
            this.CreateMap<APQPTemplateVM, APQP>();
            this.CreateMap<APQPTemplateVM, APQPTemplate>()
                .ForMember(des => des.Gates, opt => opt.Ignore());
            this.CreateMap<GateVM, Gate>()
                .ForMember(des => des.APQPTemplate, opt => opt.Ignore())
                .ForMember(des => des.CustomFields, opt => opt.Ignore())
                .ForMember(des => des.CustomFieldGateMappings, opt => opt.Ignore());
            this.CreateMap<CustomFieldAnswerOptionVM, CustomFieldAnswerOption>();
            this.CreateMap<CustomFieldGateMappingVM, CustomFieldGateMapping>()
                 .ForMember(des => des.CustomField, opt => opt.Ignore())
                 .ForMember(des => des.APQPTemplate, opt => opt.Ignore())
                 .ForMember(des => des.Gate, opt => opt.Ignore());
            this.CreateMap<SetupVM, Roles>();
            this.CreateMap<SetupVM, DocumentType>();
            this.CreateMap<EmailNotificationVM, EmailNotification>();
            this.CreateMap<CustomFieldVM, CustomField>()
                .ForMember(des => des.AnswerOptions, opt => opt.Ignore());
            this.CreateMap<CustomFieldAnswerOptionVM, CustomFieldAnswerOption>();
            this.CreateMap<APQPProjectCM, APQP>();

            this.CreateMap<APQPDataCM, APQPData>();
            this.CreateMap<CustomFieldAnswerCM, CustomFieldAnswer>();
            this.CreateMap<GateClosureSettingVM, GateClosureSetting>();
            this.CreateMap<GateClosureApprovalVM, GateClosureApproval>()
                .ForMember(des => des.Approvers, opt => opt.Ignore());
            this.CreateMap<GateClosureDocumentVM, GateClosureDocument>();
            this.CreateMap<GateClosureEmailVM, GateClosureEmail>();

            this.CreateMap<APQPDiscussionVM, Discussion>();
            this.CreateMap<ApproverVM, Approver>();
            this.CreateMap<ApproverVM, ApproverAction>()
                .ForMember(des => des.Id, opt => opt.Ignore());

            this.CreateMap<SetupVM, Designation>();

            this.CreateMap<ActivityVM, Activity>();

            this.CreateMap<UserRoleVM, UserRole>()
                 .ForMember(des => des.Role, opt => opt.Ignore());
            this.CreateMap<UserDesignationsVM, UserDesignations>()
                .ForMember(des => des.Designation, opt => opt.Ignore());

            this.CreateMap<CustomFieldPropertiesOverrideVM, CustomFieldPropertiesOverride>()
                .ForMember(des => des.APQPTemplate, opt => opt.Ignore())
                .ForMember(des => des.Gate, opt => opt.Ignore())
                .ForMember(des => des.CustomField, opt => opt.Ignore());
        }
    }
}
