// <copyright file="GetUserMenuHandler.cs" company="MESHWorksAPQP">
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
    /// Class GetUserMenuHandler.
    /// </summary>
    public class GetUserMenuHandler : ICommandHandler<GetUserMenuCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IUserManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserMenuHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetUserMenuHandler(IUserManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetUserMenuCommand command)
        {
            command.Result = await this.manager.GetUserMenu(command);
        }
    }
}
