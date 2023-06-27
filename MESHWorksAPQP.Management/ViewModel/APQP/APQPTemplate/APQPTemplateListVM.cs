// <copyright file="APQPTemplateListVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.APQP.APQPTemplate
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Management.ViewModel.APQP.Gates;
    using MESHWorksAPQP.Model.Models.APQP.Gates;

    /// <summary>
    /// Class APQPTemplateListVM.
    /// </summary>
    public class APQPTemplateListVM
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is system default; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystemDefault { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is apqp exist.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is apqp exist; otherwise, <c>false</c>.
        /// </value>
        public bool IsAPQPExist { get; set; }

        /// <summary>
        /// Gets or sets the associated parts.
        /// </summary>
        /// <value>
        /// The associated parts.
        /// </value>
        public int AssociatedParts { get; set; }

        /// <summary>
        /// Gets or sets the total gates.
        /// </summary>
        /// <value>
        /// The total gates.
        /// </value>
        public int TotalGates { get; set; }
    }
}
