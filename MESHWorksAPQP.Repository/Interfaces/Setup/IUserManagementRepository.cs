// <copyright file="IUserManagementRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Interfaces.Setup
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Repository.CustomModel.Role;

    /// <summary>
    /// Interface IUserManagementRepository.
    /// </summary>
    public interface IUserManagementRepository
    {
        /// <summary>
        /// Gets all user management.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="searchText">The search text.</param>
        /// <param name="isDeleted">if set to <c>true</c> [is deleted].</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <returns>
        /// List of UserRoleCM and List of UserDesignationsCM.
        /// </returns>
        Task<(IList<UserRoleCM>, IList<UserDesignationsCM>)> GetAllUserManagement(Guid? companyId, string searchText, bool isDeleted, int pageNumber, int pageSize, string sortBy, string sortOrder);
    }
}
