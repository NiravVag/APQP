// <copyright file="GateDataVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.APQP.Gates
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// class GateDataVM.
    /// </summary>
    public class GateDataVM
    {
        /// <summary>
        /// Gets or sets the gate identifier.
        /// </summary>
        /// <value>
        /// The gate identifier.
        /// </value>
        public Guid GateId { get; set; }

        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the form custom field answers.
        /// </summary>
        /// <value>
        /// The form custom field answers.
        /// </value>
        public List<FormCustomFieldAnswerVM> CustomFieldAnswers { get; set; }
    }
}
