// <copyright file="IUserRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces.User
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Repository.CustomModel;

    /// <summary>
    /// Interface IUserRepository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the user menu.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// List of UserMenuDetail.
        /// </returns>
        Task<IList<UserMenuDetail>> GetUserMenu(Guid? companyId, Guid userId);

        /// <summary>
        /// Gets the user permissions.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// List of PermissionDetail.
        /// </returns>
        Task<IList<PermissionDetail>> GetUserPermissions(Guid? companyId, Guid userId);
    }
}
