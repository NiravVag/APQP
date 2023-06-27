// <copyright file="CompanyModule.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Role
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Models.Setup;

    /// <summary>
    /// Class CompanyModule.
    /// </summary>
    [Table("CompanyModules", Schema = "Role")]
    public class CompanyModule : BaseEntity
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the moduletype identifier.
        /// </summary>
        /// <value>
        /// The moduletype identifier.
        /// </value>
        public Guid ModuleTypeId { get; set; }

        /// <summary>
        /// Gets or sets the certification.
        /// </summary>
        /// <value>
        /// The certification.
        /// </value>
        public virtual ModuleType ModuleType { get; set; }
    }
}
