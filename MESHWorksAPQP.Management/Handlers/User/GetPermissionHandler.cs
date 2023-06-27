// <copyright file="GetPermissionHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.User;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.User;

    /// <summary>
    /// Class GetPermissionHandler.
    /// </summary>
    public class GetPermissionHandler : ICommandHandler<GetPermissionCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IUserManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPermissionHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetPermissionHandler(IUserManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetPermissionCommand command)
        {
            command.Result = await this.manager.GetUserPermissions(command);
        }
    }
}
