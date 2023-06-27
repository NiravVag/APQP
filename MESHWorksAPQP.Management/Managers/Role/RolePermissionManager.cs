// <copyright file="RolePermissionManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Role
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Dynamic.Core;
    using System.Threading.Tasks;
    using AutoMapper;
    using MESHWorksAPQP.Management.Commands.Role.RolePermission;
    using MESHWorksAPQP.Management.Interface.Managers.Role;
    using MESHWorksAPQP.Model.Models.Role;
    using MESHWorksAPQP.Repository.CustomModel;
    using MESHWorksAPQP.Repository.Interfaces;
    using MESHWorksAPQP.Repository.Interfaces.Role;
    using MESHWorksAPQP.Shared.Interface;

    /// <summary>
    /// Class RolePermissionManager.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Managers.Company.IRolePermissionManager" />
    public class RolePermissionManager : IRolePermissionManager
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRolePermissionRepository repository;

        /// <summary>
        /// The user role repository.
        /// </summary>
        private readonly IGenericRepository<UserRole> userRoleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolePermissionManager" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="userRoleRepository">The user role repository.</param>
        public RolePermissionManager(
           IMapper mapper,
           IRolePermissionRepository repository,
           IGenericRepository<UserRole> userRoleRepository)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.userRoleRepository = userRoleRepository;
        }

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List Of RolePermissionDetail.
        /// </returns>
        /// <exception cref="ValidationException">Invalid Request.</exception>
        public async Task<List<RolePermissionDetail>> Save(SaveRolePermissionCommand command)
        {
            if (command.UserId != Guid.Empty && command.RoleId != Guid.Empty && command.Entity.Any())
            {
                var items = await this.repository.SaveRolePermissions(command.UserId, command.RoleId, command.CompanyId, command.Entity);
                return this.mapper.Map<List<RolePermissionDetail>>(items.ToList());
            }

            throw new ValidationException("Invalid Request.");
        }

        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List Of RolePermissionDetail.</returns>
        public async Task<IList<RolePermissionDetail>> Search(SearchRolePermissionCommand command)
        {
            if (command.UserId != Guid.Empty && command.RoleId != Guid.Empty)
            {
                var items = await this.repository.GetRolePermissions(command.RoleId, command.CompanyId);
                return items;
            }

            throw new ValidationException("Invalid Request.");
        }
    }
}
