// <copyright file="FormCustomFieldAnswerVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.APQP.Gates
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// class FormCustomFieldAnswerVM.
    /// </summary>
    public class FormCustomFieldAnswerVM
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or sets the answer value.
        /// </summary>
        /// <value>
        /// The answer value.
        /// </value>
        public List<string> AnswerValue { get; set; }

        /// <summary>
        /// Gets or sets the custom field identifier.
        /// </summary>
        /// <value>
        /// The custom field identifier.
        /// </value>
        public Guid CustomFieldId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

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
        public string PredefindFieldName { get; set; }
    }
}