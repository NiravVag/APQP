// <copyright file="GetRoleHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.Role
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Role;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Role;

    /// <summary>
    /// Class GetRoleHandler.
    /// </summary>
    public class GetRoleHandler : ICommandHandler<GetRoleCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IRoleManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRoleHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetRoleHandler(IRoleManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetRoleCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}
