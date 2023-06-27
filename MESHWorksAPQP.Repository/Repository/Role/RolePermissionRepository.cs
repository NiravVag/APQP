// <copyright file="RolePermissionRepository.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.Repository.Role
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Models.Role;
    using MESHWorksAPQP.Repository.Context;
    using MESHWorksAPQP.Repository.CustomModel;
    using MESHWorksAPQP.Repository.Extensions;
    using MESHWorksAPQP.Repository.Interfaces.Role;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class RolePermissionRepository.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Repository.Repository.GenericRepository{MESHWorksAPQP.Model.Models.Role.RolePermissions}" />
    /// <seealso cref="MESHWorksAPQP.Repository.Interfaces.Role.IRolePermissionRepository" />
    public class RolePermissionRepository : GenericRepository<RolePermissions>, IRolePermissionRepository
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// The user identity.
        /// </summary>
        private readonly IUserIdentity userIdentity;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolePermissionRepository" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public RolePermissionRepository(ApplicationDbContext dbContext, IUserIdentity userIdentity)
            : base(dbContext, userIdentity)
        {
            this.userIdentity = userIdentity;
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets the role permissions.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns>
        /// List of RolePermissionDetail.
        /// </returns>
        public async Task<IList<RolePermissionDetail>> GetRolePermissions(Guid? roleId, Guid? companyId)
        {
            IList<RolePermissionDetail> rolePermissions = null;

            await this.dbContext.LoadStoredProc("[Role].[GetRolePermissions]")
               .WithSqlParam("RoleId", roleId)
               .WithSqlParam("CompanyId", companyId)
               .ExecuteStoredProcAsync((handler) =>
               {
                   rolePermissions = handler.ReadToList<RolePermissionDetail>();
               });

            if (rolePermissions != null && rolePermissions.Any())
            {
                foreach (var item in rolePermissions)
                {
                    if (item.HasRead)
                    {
                        item.PermissionType = Shared.Enum.PermissionType.Read;
                    }
                    else if (item.HasWrite)
                    {
                        item.PermissionType = Shared.Enum.PermissionType.Write;
                    }
                    else if (item.HasNone)
                    {
                        item.PermissionType = Shared.Enum.PermissionType.None;
                    }
                    else
                    {
                        item.HasNone = true;
                        item.PermissionType = Shared.Enum.PermissionType.None;
                    }
                }
            }

            return rolePermissions;
        }

        /// <summary>
        /// Saves the role permissions.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="rolePermissions">The role permissions.</param>
        /// <returns>
        /// List of RolePermissionDetail.
        /// </returns>
        public async Task<List<RolePermissionDetail>> SaveRolePermissions(Guid userId, Guid? roleId, Guid? companyId, List<RolePermissionDetail> rolePermissions)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(rolePermissions);

            await this.dbContext.LoadStoredProc("[Role].[SaverolePermissions]")
                .WithSqlParam("UserId", userId)
                .WithSqlParam("RoleId", roleId)
                .WithSqlParam("CompanyId", companyId)
                .WithSqlParam("json", json.ToString())
              .ExecuteStoredProcAsync((handler) =>
              {
                  rolePermissions = handler.ReadToList<RolePermissionDetail>().ToList();
              });

            return rolePermissions;
        }
    }
}
