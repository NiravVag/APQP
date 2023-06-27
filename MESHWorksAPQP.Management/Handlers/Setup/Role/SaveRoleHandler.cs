// <copyright file="SaveRoleHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.Role
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Role;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Role;

    /// <summary>
    /// Class SaveProcessHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Setup.SaveRoleCommand}" />
    public class SaveRoleHandler : ICommandHandler<SaveRoleCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IRoleManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveRoleHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SaveRoleHandler(IRoleManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SaveRoleCommand command)
        {
            command.Result = await this.manager.Save(command);
        }
    }
}
