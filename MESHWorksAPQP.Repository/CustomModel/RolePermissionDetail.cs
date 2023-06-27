// <copyright file="RolePermissionDetail.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// Class RolePermissionDetail.
    /// </summary>
    public class RolePermissionDetail
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }

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
        /// Gets or sets the type of the permission.
        /// </summary>
        /// <value>
        /// The type of the permission.
        /// </value>
        public PermissionType PermissionType { get; set; }
    }
}
