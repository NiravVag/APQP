// <copyright file="PermissionDetail.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel
{
    using System;

    /// <summary>
    /// Class PermissionDetail.
    /// </summary>
    public class PermissionDetail
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the entity company identifier.
        /// </summary>
        /// <value>
        /// The entity company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// Gets or sets the Companyusertype identifier.
        /// </summary>
        /// <value>
        /// The Companyusertype identifier.
        /// </value>
        public Guid? CompanyUserTypeId { get; set; }

        /// <summary>
        /// Gets or sets the moduletype identifier.
        /// </summary>
        /// <value>
        /// The moduletype identifier.
        /// </value>
        public Guid? ModuleTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the pagetype.
        /// </summary>
        /// <value>
        /// The name of the pagetype.
        /// </value>
        public string ModuleType { get; set; }

        /// <summary>
        /// Gets or sets the pagetype identifier.
        /// </summary>
        /// <value>
        /// The pagetype identifier.
        /// </value>
        public Guid? PageTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the moduletype.
        /// </summary>
        /// <value>
        /// The name of the moduletype.
        /// </value>
        public string PageType { get; set; }

        /// <summary>
        /// Gets or sets the name of code.
        /// </summary>
        /// <value>
        /// The name of code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the page URL.
        /// </summary>
        /// <value>
        /// The page URL.
        /// </value>
        public string PageUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is allow page record read.
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
        /// Gets or sets a value indicating whether this is allow page record.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has none; otherwise, <c>false</c>.
        /// </value>
        public bool HasNone { get; set; }
    }
}
