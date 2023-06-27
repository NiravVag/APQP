// <copyright file="CompanyUserType.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Role
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Models.Role;

    /// <summary>
    /// Class CompanyUserType.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity" />
    [Table("CompanyUserType", Schema = "Role")]
    public class CompanyUserType : BaseEntity
    {
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
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system created.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is system created; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystemCreated { get; set; }

        /// <summary>
        /// Gets or sets the role permissions.
        /// </summary>
        /// <value>
        /// The role permissions.
        /// </value>
        public virtual ICollection<RolePermissions> RolePermissions { get; set; }
    }
}
