// <copyright file="IRolePermissionManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Role
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Role.RolePermission;
    using MESHWorksAPQP.Repository.CustomModel;

    /// <summary>
    /// Interface IRolePermissionManager.
    /// </summary>
    public interface IRolePermissionManager
    {
        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of RolePermissionDetail.</returns>
        Task<IList<RolePermissionDetail>> Search(SearchRolePermissionCommand command);

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List of RolePermissionDetail.
        /// </returns>
        Task<List<RolePermissionDetail>> Save(SaveRolePermissionCommand command);
    }
}
