// <copyright file="ApplicationDbContext.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.Activity;
    using MESHWorksAPQP.Model.Models.APQP;
    using MESHWorksAPQP.Model.Models.APQP.Template;
    using MESHWorksAPQP.Model.Models.APQP.WorkFlow;
    using MESHWorksAPQP.Model.Models.CustomField;
    using MESHWorksAPQP.Model.Models.Discussions;
    using MESHWorksAPQP.Model.Models.Documents;
    using MESHWorksAPQP.Model.Models.Email;
    using MESHWorksAPQP.Model.Models.Parts;
    using MESHWorksAPQP.Model.Models.Role;
    using MESHWorksAPQP.Model.Models.Setup;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    /// <summary>
    /// Class ApplicationDbContext.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{MESHWorksAPQP.Model.Models.User, Microsoft.AspNetCore.Identity.IdentityRole{System.Guid}, System.Guid}" />
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the part.
        /// </summary>
        /// <value>
        /// The part.
        /// </value>
        public DbSet<Part> Part { get; set; }

        /// <summary>
        /// Gets or sets the part relation.
        /// </summary>
        /// <value>
        /// The part relation.
        /// </value>
        public DbSet<PartRelation> PartRelation { get; set; }

        /// <summary>
        /// Gets or sets the apqp.
        /// </summary>
        /// <value>
        /// The apqp.
        /// </value>
        public DbSet<APQP> APQP { get; set; }

        /// <summary>
        /// Gets or sets the apqp data.
        /// </summary>
        /// <value>
        /// The apqp data.
        /// </value>
        public DbSet<APQPData> APQPData { get; set; }

        /// <summary>
        /// Gets or sets the apqp template.
        /// </summary>
        /// <value>
        /// The apqp template.
        /// </value>
        public DbSet<APQPTemplate> APQPTemplate { get; set; }

        /// <summary>
        /// Gets or sets the gate closure setting.
        /// </summary>
        /// <value>
        /// The gate closure setting.
        /// </value>
        public DbSet<GateClosureSetting> GateClosureSetting { get; set; }

        /// <summary>
        /// Gets or sets the gate closure.
        /// </summary>
        /// <value>
        /// The gate closure.
        /// </value>
        public DbSet<GateClosure> GateClosure { get; set; }

        /// <summary>
        /// Gets or sets the gate closure document.
        /// </summary>
        /// <value>
        /// The gate closure document.
        /// </value>
        public DbSet<GateClosureDocument> GateClosureDocument { get; set; }

        /// <summary>
        /// Gets or sets the gate closure email.
        /// </summary>
        /// <value>
        /// The gate closure email.
        /// </value>
        public DbSet<GateClosureEmail> GateClosureEmail { get; set; }

        /// <summary>
        /// Gets or sets the gate closure approval.
        /// </summary>
        /// <value>
        /// The gate closure approval.
        /// </value>
        public DbSet<GateClosureApproval> GateClosureApproval { get; set; }

        /// <summary>
        /// Gets or sets the custom field.
        /// </summary>
        /// <value>
        /// The custom field.
        /// </value>
        public DbSet<CustomField> CustomField { get; set; }

        /// <summary>
        /// Gets or sets the custom field answer.
        /// </summary>
        /// <value>
        /// The custom field answer.
        /// </value>
        public DbSet<CustomFieldAnswer> CustomFieldAnswer { get; set; }

        /// <summary>
        /// Gets or sets the custom field answer option.
        /// </summary>
        /// <value>
        /// The custom field answer option.
        /// </value>
        public DbSet<CustomFieldAnswerOption> CustomFieldAnswerOption { get; set; }

        /// <summary>
        /// Gets or sets the custom field gate mapping.
        /// </summary>
        /// <value>
        /// The custom field gate mapping.
        /// </value>
        public DbSet<CustomFieldGateMapping> CustomFieldGateMapping { get; set; }

        /// <summary>
        /// Gets or sets the field answer options binding.
        /// </summary>
        /// <value>
        /// The field answer options binding.
        /// </value>
        public DbSet<FieldAnswerOptionsBinding> FieldAnswerOptionsBinding { get; set; }

        /// <summary>
        /// Gets or sets the discussion.
        /// </summary>
        /// <value>
        /// The discussion.
        /// </value>
        public DbSet<Discussion> Discussion { get; set; }

        /// <summary>
        /// Gets or sets the automatic increment entity.
        /// </summary>
        /// <value>
        /// The automatic increment entity.
        /// </value>
        public DbSet<AutoIncrementEntity> AutoIncrementEntity { get; set; }

        /// <summary>
        /// Gets or sets the commodity.
        /// </summary>
        /// <value>-
        /// </value>
        public DbSet<Commodity> Commodity { get; set; }

        /// <summary>
        /// Gets or sets the type of the document.
        /// </summary>
        /// <value>
        /// The type of the document.
        /// </value>
        public DbSet<DocumentType> DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the email notification.
        /// </summary>
        /// <value>
        /// The email notification.
        /// </value>
        public DbSet<EmailNotification> EmailNotification { get; set; }

        /// <summary>
        /// Gets or sets the type of the material.
        /// </summary>
        /// <value>
        /// The type of the material.
        /// </value>
        public DbSet<MaterialType> MaterialType { get; set; }

        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>
        /// The module.
        /// </value>
        public DbSet<Module> Module { get; set; }

        /// <summary>
        /// Gets or sets the type of the module.
        /// </summary>
        /// <value>
        /// The type of the module.
        /// </value>
        public DbSet<ModuleType> ModuleType { get; set; }

        /// <summary>
        /// Gets or sets the type of the page.
        /// </summary>
        /// <value>
        /// The type of the page.
        /// </value>
        public DbSet<PageType> PageType { get; set; }

        /// <summary>
        /// Gets or sets the process.
        /// </summary>
        /// <value>
        /// The process.
        /// </value>
        public DbSet<Process> Process { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public DbSet<Roles> Roles { get; set; }

        /// <summary>
        /// Gets or sets the document attachment.
        /// </summary>
        /// <value>
        /// The document attachment.
        /// </value>
        public DbSet<Document> Document { get; set; }

        /// <summary>
        /// Gets or sets the place holder of the email.
        /// </summary>
        /// <value>
        /// The email place holder.
        /// </value>
        public DbSet<EmailPlaceHolder> EmailPlaceHolder { get; set; }

        /// <summary>
        /// Gets or sets the email configuration.
        /// </summary>
        /// <value>
        /// The email configuration.
        /// </value>
        public DbSet<EmailConfiguration> EmailConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the template of the email.
        /// </summary>
        /// <value>
        /// The email template.
        /// </value>
        public DbSet<EmailTemplate> EmailTemplate { get; set; }

        /// <summary>
        /// Gets or sets the email messsage.
        /// </summary>
        /// <value>
        /// The email message.
        /// </value>
        public DbSet<EmailMessage> EmailMessage { get; set; }

        /// <summary>
        /// Gets or sets the email attachment.
        /// </summary>
        /// <value>
        /// The email attachment.
        /// </value>
        public DbSet<EmailAttachment> EmailAttachment { get; set; }

        /// <summary>
        /// Gets or sets the email notification preference.
        /// </summary>
        /// <value>
        /// The email notification preference.
        /// </value>
        public DbSet<EmailNotificationPreference> EmailNotificationPreference { get; set; }

        /// <summary>
        /// Gets or sets the email notification preference user.
        /// </summary>
        /// <value>
        /// The email notification preference user.
        /// </value>
        public DbSet<EmailNotificationPreferenceUser> EmailNotificationPreferenceUser { get; set; }

        /// <summary>
        /// Gets or sets the company module.
        /// </summary>
        /// <value>
        /// The company module.
        /// </value>
        public DbSet<CompanyModule> CompanyModule { get; set; }

        /// <summary>
        /// Gets or sets the type of the company user.
        /// </summary>
        /// <value>
        /// The type of the company user.
        /// </value>
        public DbSet<CompanyUserType> CompanyUserType { get; set; }

        /// <summary>
        /// Gets or sets the role permissions.
        /// </summary>
        /// <value>
        /// The role permissions.
        /// </value>
        public DbSet<RolePermissions> RolePermissions { get; set; }

        /// <summary>
        /// Gets or sets the approver.
        /// </summary>
        /// <value>
        /// The approver.
        /// </value>
        public DbSet<Approver> Approver { get; set; }

        /// <summary>
        /// Gets or sets the approver action.
        /// </summary>
        /// <value>
        /// The approver action.
        /// </value>
        public DbSet<ApproverAction> ApproverAction { get; set; }

        /// <summary>
        /// Gets or sets the activity.
        /// </summary>
        /// <value>
        /// The activity.
        /// </value>
        public DbSet<Activity> Activity { get; set; }

        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        /// <value>
        /// The type of the user.
        /// </value>
        public DbSet<UserRole> UserRole { get; set; }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        /// <value>
        /// The designation.
        /// </value>
        public DbSet<Designation> Designation { get; set; }

        /// <summary>
        /// Gets or sets the user designations.
        /// </summary>
        /// <value>
        /// The user designations.
        /// </value>
        public DbSet<UserDesignations> UserDesignations { get; set; }

        /// <summary>
        /// Gets or sets the custom field properties override.
        /// </summary>
        /// <value>
        /// The custom field properties override.
        /// </value>
        public DbSet<CustomFieldPropertiesOverride> CustomFieldPropertiesOverride { get; set; }

        /// <summary>
        /// Configures the schema needed for the identity framework.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
        .SelectMany(t => t.GetForeignKeys())
        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(18);
                property.SetScale(6);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}