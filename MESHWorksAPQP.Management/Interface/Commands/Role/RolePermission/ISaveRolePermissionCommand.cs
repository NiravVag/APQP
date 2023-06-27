// <copyright file="ISaveRolePermissionCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Commands.Role.RolePermission
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Repository.CustomModel;

    /// <summary>
    /// Interface ISaveRolePermissionCommand.
    /// </summary>
    public interface ISaveRolePermissionCommand
    {
        /// <summary>
        /// Gets or sets the companyusertype identifier.
        /// </summary>
        /// <value>
        /// The companyusertype identifier.
        /// </value>
        Guid? CompanyUserTypeId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        Guid? RoleId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the question section.
        /// </summary>
        /// <value>
        /// The question section.
        /// </value>
        public List<RolePermissionDetail> Entity { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public List<RolePermissionDetail> Result { get; set; }
    }
}