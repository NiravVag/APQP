// <copyright file="Roles.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Setup
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Interface;

    /// <summary>
    /// Class Roles.
    /// </summary>
    /// <seealso cref="MESHWorks.Model.Abstract.BaseEntity{System.Guid}" />
    [Table("Roles", Schema = "Setup")]
    public class Roles : SetupBaseEntity, ISetupBaseEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is system role.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is system role; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }
    }
}
