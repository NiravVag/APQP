// <copyright file="UserManagementVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Setup.UserManagement
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Management.Interface.ViewModel;
    using MESHWorksAPQP.Model.Models.Role;

    /// <summary>
    /// class UserManagementVM.
    /// </summary>
    public class UserManagementVM : ISaveResult
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
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
        /// Gets or sets the user role.
        /// </summary>
        /// <value>
        /// The user role.
        /// </value>
        public UserRoleVM UserRole { get; set; }

        /// <summary>
        /// Gets or sets the designation ids.
        /// </summary>
        /// <value>
        /// The designation ids.
        /// </value>
        public List<Guid> DesignationIds { get; set; }

        /// <summary>
        /// Gets or sets the user designations.
        /// </summary>
        /// <value>
        /// The user designations.
        /// </value>
        public List<UserDesignationsVM> UserDesignations { get; set; }
    }
}
