// <copyright file="RolePermissions.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Role
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Models.Setup;

    /// <summary>
    /// Class RolePermissions.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity" />
    [Table("RolePermissions", Schema = "Role")]
    public class RolePermissions : BaseEntity
    {
        /// <summary>
        /// Gets or sets the pagetype identifier.
        /// </summary>
        /// <value>
        /// The pagetype identifier.
        /// </value>
        public Guid PageTypeId { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public virtual PageType PageType { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public virtual Roles Role { get; set; }

        /// <summary>
        /// Gets or sets the Companyusertype identifier.
        /// </summary>
        /// <value>
        /// The Companyusertype identifier.
        /// </value>
        public Guid? CompanyUserTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Companyusertype.
        /// </summary>
        /// <value>
        /// The Companyusertype.
        /// </value>
        public virtual CompanyUserType CompanyUserType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is allow page record read.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is allow page record read; otherwise, <c>false</c>.
        /// </value>
        public bool HasRead { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is allow page record write.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is allow page record write; otherwise, <c>false</c>.
        /// </value>
        public bool HasWrite { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is allow page record.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is allow page record; otherwise, <c>false</c>.
        /// </value>
        public bool HasNone { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }
    }
}
