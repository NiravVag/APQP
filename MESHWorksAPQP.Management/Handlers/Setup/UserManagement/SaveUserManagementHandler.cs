// <copyright file="SaveUserManagementHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.UserManagement
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.UserManagement;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.UserManagement;

    /// <summary>
    /// Class SaveUserManagementHandler.
    /// </summary>
    public class SaveUserManagementHandler : ICommandHandler<SaveUserManagementCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IUserManagementManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveUserManagementHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SaveUserManagementHandler(IUserManagementManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SaveUserManagementCommand command)
        {
            command.Result = await this.manager.Save(command);
        }
    }
}
