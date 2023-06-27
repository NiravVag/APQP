// <copyright file="CustomFieldGateMappingVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.CustomField
{
    using System;
    using MESHWorksAPQP.Management.ViewModel.APQP;
    using MESHWorksAPQP.Management.ViewModel.APQP.Gates;

    /// <summary>
    /// Class CustomFieldGateMappingVM.
    /// </summary>
    public class CustomFieldGateMappingVM
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the custom field identifier.
        /// </summary>
        /// <value>
        /// The custom field identifier.
        /// </value>
        public Guid CustomFieldId { get; set; }

        /// <summary>
        /// Gets or sets the template identifier.
        /// </summary>
        /// <value>
        /// The template identifier.
        /// </value>
        public Guid APQPTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the gate identifier.
        /// </summary>
        /// <value>
        /// The gate identifier.
        /// </value>
        public Guid GateId { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        /// <value>
        /// The row.
        /// </value>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the col.
        /// </summary>
        /// <value>
        /// The col.
        /// </value>
        public int Column { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the custom field.
        /// </summary>
        /// <value>
        /// The custom field.
        /// </value>
        public CustomFieldVM CustomField { get; set; }

        /// <summary>
        /// Gets or sets the custom field properties override.
        /// </summary>
        /// <value>
        /// The custom field properties override.
        /// </value>
        public CustomFieldPropertiesOverrideVM CustomFieldPropertiesOverride { get; set; }
    }
}
