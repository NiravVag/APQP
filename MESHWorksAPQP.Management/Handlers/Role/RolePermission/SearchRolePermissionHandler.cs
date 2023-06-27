// <copyright file="SearchRolePermissionHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Role.RolePermission
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Role.RolePermission;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Role;

    /// <summary>
    /// Class SearchRolePermissionHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Role.RolePermission.SearchRolePermissionCommand}" />
    public class SearchRolePermissionHandler : ICommandHandler<SearchRolePermissionCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IRolePermissionManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchRolePermissionHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SearchRolePermissionHandler(IRolePermissionManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SearchRolePermissionCommand command)
        {
            command.Result = await this.manager.Search(command);
        }
    }
}