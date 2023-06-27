﻿// <copyright file="CustomFieldPropertiesOverride.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.CustomField
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Models.APQP.Gates;
    using MESHWorksAPQP.Model.Models.APQP.Template;

    /// <summary>
    /// Class CustomFieldPropertiesOverride.
    /// </summary>
    [Table("CustomFieldPropertiesOverride", Schema = "CustomField")]
    public class CustomFieldPropertiesOverride : BaseEntity
    {
        /// <summary>
        /// Gets or sets the apqp template identifier.
        /// </summary>
        /// <value>
        /// The apqp template identifier.
        /// </value>
        public Guid APQPTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the apqp template.
        /// </summary>
        /// <value>
        /// The apqp template.
        /// </value>
        public virtual APQPTemplate APQPTemplate { get; set; }

        /// <summary>
        /// Gets or sets the custom field identifier.
        /// </summary>
        /// <value>
        /// The custom field identifier.
        /// </value>
        public Guid CustomFieldId { get; set; }

        /// <summary>
        /// Gets or sets the custom field.
        /// </summary>
        /// <value>
        /// The custom field.
        /// </value>
        public virtual CustomField CustomField { get; set; }

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
        /// Gets or sets a value indicating whether this instance is visible on selection.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is visible on selection; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisibleOnSelection { get; set; }

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
        /// Gets or sets the minimum date.
        /// </summary>
        /// <value>
        /// The minimum date.
        /// </value>
        public DateTime? MinDate { get; set; }

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

        /// <summary>
        /// Gets or sets the gate identifier.
        /// </summary>
        /// <value>
        /// The gate identifier.
        /// </value>
        public Guid GateId { get; set; }

        /// <summary>
        /// Gets or sets the gate.
        /// </summary>
        /// <value>
        /// The gate.
        /// </value>
        public virtual Gate Gate { get; set; }
    }
}