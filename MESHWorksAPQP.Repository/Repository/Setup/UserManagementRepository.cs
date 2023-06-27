// <copyright file="UserManagementRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.Setup
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.CustomModel.Role;
    using MESHWorksAPQP.Repository.Extensions;
    using MESHWorksAPQP.Repository.Interfaces.Setup;

    /// <summary>
    /// Class UserManagementRepository.
    /// </summary>
    public class UserManagementRepository : IUserManagementRepository
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManagementRepository" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UserManagementRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

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
        public async Task<(IList<UserRoleCM>, IList<UserDesignationsCM>)> GetAllUserManagement(Guid? companyId, string searchText, bool isDeleted, int pageNumber, int pageSize, string sortBy, string sortOrder)
        {
            IList<UserRoleCM> userRoles = null;
            IList<UserDesignationsCM> userDesignations = null;

            await this.dbContext.LoadStoredProc("[Setup].[GetAllUserManagement]")
              .WithSqlParam("CompanyId", companyId)
              .ExecuteStoredProcAsync((handler) =>
              {
                  userRoles = handler.ReadToList<UserRoleCM>();
                  handler.NextResult();
                  userDesignations = handler.ReadToList<UserDesignationsCM>();
                  handler.NextResult();
              });

            return (userRoles, userDesignations);
        }
    }
}
