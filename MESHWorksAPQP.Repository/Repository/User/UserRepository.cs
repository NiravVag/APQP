// <copyright file="UserRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.User
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.CustomModel;
    using MESHWorksAPQP.Repository.Extensions;
    using MESHWorksAPQP.Repository.Interfaces.User;

    /// <summary>
    /// Class UserRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.User.IUserRepository" />
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the user menu.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// List of UserMenuDetail.
        /// </returns>
        public async Task<IList<UserMenuDetail>> GetUserMenu(Guid? companyId, Guid userId)
        {
            IList<UserMenuDetail> userMenus = null;
            await this.dbContext.LoadStoredProc("Role.GetUserMenu")
               .WithSqlParam("CompanyId", companyId)
               .WithSqlParam("UserId", userId)
               .ExecuteStoredProcAsync((handler) =>
               {
                   userMenus = handler.ReadToList<UserMenuDetail>();
               });

            return userMenus;
        }

        /// <summary>
        /// Gets the user permissions.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// List of PermissionDetail.
        /// </returns>
        public async Task<IList<PermissionDetail>> GetUserPermissions(Guid? companyId, Guid userId)
        {
            IList<PermissionDetail> userPermissions = null;
            await this.dbContext.LoadStoredProc("Role.GetUserPermissions")
                .WithSqlParam("UserId", userId)
                .WithSqlParam("CompanyId", companyId)
                .ExecuteStoredProcAsync((handler) =>
                {
                    userPermissions = handler.ReadToList<PermissionDetail>();
                });

            return userPermissions;
        }
    }
}
