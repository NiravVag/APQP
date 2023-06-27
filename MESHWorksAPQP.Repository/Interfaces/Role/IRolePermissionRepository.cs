// <copyright file="IRolePermissionRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces.Role
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.Role;
    using MESHWorksAPQP.Repository.CustomModel;

    /// <summary>
    /// Interface IRolePermissionRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.IGenericRepository{MESHWorksAPQP.Model.Models.Role.RolePermissions}" />
    public interface IRolePermissionRepository : IGenericRepository<RolePermissions>
    {
        /// <summary>
        /// Gets the role permissions.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>List of RolePermissionDetail.</returns>
        Task<IList<RolePermissionDetail>> GetRolePermissions(Guid? roleId, Guid? companyId);

        /// <summary>
        /// Saves the role permissions.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="rolePermissions">The role permissions.</param>
        /// <returns>List of RolePermissionDetail.</returns>
        Task<List<RolePermissionDetail>> SaveRolePermissions(Guid userId, Guid? roleId, Guid? companyId, List<RolePermissionDetail> rolePermissions);
    }
}
