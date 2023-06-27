// <copyright file="CustomFieldVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.CustomField
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MESHWorksAPQP.Management.Interface.ViewModel;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// Class CustomFieldVM.
    /// </summary>
    public class CustomFieldVM : ISaveResult
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the type of the field.
        /// </summary>
        /// <value>
        /// The type of the field.
        /// </value>
        public FieldType FieldType { get; set; }

        /// <summary>
        /// Gets or sets the tooltip.
        /// </summary>
        /// <value>
        /// The tooltip.
        /// </value>
        [MaxLength(200)]
        public string Tooltip { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is required.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is required; otherwise, <c>false</c>.
        /// </value>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the validation regex.
        /// </summary>
        /// <value>
        /// The validation regex.
        [MaxLength(200)]
        public string ValidationRegex { get; set; }

        /// <summary>
        /// Gets or sets the validation message.
        /// </summary>
        /// <value>
        /// The validation message.
        /// </value>
        [MaxLength(200)]
        public string ValidationMessage { get; set; }

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        /// <value>
        /// The default value.
        /// </value>
        [MaxLength(100)]
        public string DefaultValue { get; set; }

        /// <summary>
        /// Gets or sets the parent feild identifier.
        /// </summary>
        /// <value>
        /// The parent feild identifier.
        /// </value>
        public Guid? ParentFeildId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is predefind field.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is predefind field; otherwise, <c>false</c>.
        /// </value>
        public bool IsPredefindField { get; set; }

        /// <summary>
        /// Gets or sets the name of the predefind field.
        /// </summary>
        /// <value>
        /// The name of the predefind field.
        /// </value>
        [MaxLength(100)]
        public string PredefindFieldName { get; set; }

        /// <summary>
        /// Gets or sets the field answer options binding identifier.
        /// </summary>
        /// <value>
        /// The field answer options binding identifier.
        /// </value>
        public Guid? FieldAnswerOptionsBindingId { get; set; }

        /// <summary>
        /// Gets or sets the module identifier.
        /// </summary>
        /// <value>
        /// The module identifier.
        /// </value>
        public Guid? ModuleId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is visible on selection.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is visible on selection; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisibleOnSelection { get; set; }

        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        /// <value>
        /// The locations.
        /// </value>
        public List<CustomFieldAnswerOptionVM> AnswerOptions { get; set; }

        /// <summary>
        /// Gets or sets the custom field answer.
        /// </summary>
        /// <value>
        /// The custom field answer.
        /// </value>
        public List<CustomFieldAnswerVM> CustomFieldAnswers { get; set; }

        /// <summary>
        /// Gets or sets the bindingfunction.
        /// </summary>
        /// <value>
        /// The bindingfunction.
        /// </value>
        public string Bindingfunction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>
        /// The minimum value.
        /// </value>
        public int? MinValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public int? MaxValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum date.
        /// </summary>
        /// <value>
        /// The maximum date.
        /// </value>
        public DateTime? MaxDate { get; set; }

        /// <summary>
        /// Gets or sets the minimum length.
        /// </summary>
        /// <value>
        /// The minimum length.
        /// </value>
        public int? MinLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>
        /// The maximum length.
        /// </value>
        public int? MaxLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is multi select.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is multi select; otherwise, <c>false</c>.
        /// </value>
        public bool IsMultiSelect { get; set; }

    }
}
