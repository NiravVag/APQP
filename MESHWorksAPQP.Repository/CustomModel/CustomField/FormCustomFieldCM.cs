// <copyright file="FormCustomFieldCM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel.CustomField
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// Class FormCustomFieldCM.
    /// </summary>
    public class FormCustomFieldCM
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

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
        /// </value>
        public string ValidationRegex { get; set; }

        /// <summary>
        /// Gets or sets the validation message.
        /// </summary>
        /// <value>
        /// The validation message.
        /// </value>
        public string ValidationMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is internal use only.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is internal use only; otherwise, <c>false</c>.
        /// </value>
        public bool IsInternalUseOnly { get; set; }

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        /// <value>
        /// The default value.
        /// </value>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Gets or sets the answer value.
        /// </summary>
        /// <value>
        /// The answer value.
        /// </value>
        public string AnswerValue { get; set; }

        /// <summary>
        /// Gets or sets the answer options.
        /// </summary>
        /// <value>
        /// The answer options.
        /// </value>
        public IList<FormCustomFieldAnswerOptionCM> AnswerOptions { get; set; }

        /// <summary>
        /// Gets or sets the answers.
        /// </summary>
        /// <value>
        /// The answers.
        /// </value>
        public IList<FormCustomFieldAnswerCM> Answers { get; set; }
    }
}
