// <copyright file="SearchRolePermissionCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.Role.RolePermission
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Management.Interface.Commands.Role.RolePermission;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Repository.CustomModel;

    /// <summary>
    /// Class SearchRolePermissionCommand.
    /// </summary>
    public class SearchRolePermissionCommand : List<RolePermissionDetail>, ISearchRolePermissionCommand
    {
        /// <summary>
        /// Gets or sets the companyusertype identifier.
        /// </summary>
        /// <value>
        /// The companyusertype identifier.
        /// </value>
        public Guid? CompanyUserTypeId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public FilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public IList<RolePermissionDetail> Result { get; set; }
    }
}
