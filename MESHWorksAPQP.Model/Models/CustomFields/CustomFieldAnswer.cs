// <copyright file="CustomFieldAnswer.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.CustomField
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;

    /// <summary>
    /// class CustomFieldAnswer.
    /// </summary>
    [Table("CustomFieldAnswer", Schema = "CustomField")]
    public class CustomFieldAnswer : BaseEntity
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

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
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public Guid EntityId { get; set; }

        /// <summary>
        /// Gets or sets the answer value.
        /// </summary>
        /// <value>
        /// The answer value.
        public string AnswerValue { get; set; }
    }
}
