// <copyright file="DeleteRoleHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.Role
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Role;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Role;

    /// <summary>
    /// Class DeleteRoleHandler.
    /// </summary>
    public class DeleteRoleHandler : ICommandHandler<DeleteRoleCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IRoleManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteRoleHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public DeleteRoleHandler(IRoleManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DeleteRoleCommand command)
        {
            command.Result = await this.manager.Delete(command.Id);
        }
    }
}
