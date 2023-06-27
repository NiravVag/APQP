// <copyright file="GetUserManagementHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.UserManagement
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.UserManagement;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.UserManagement;

    /// <summary>
    /// Class GetUserManagementHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler&lt;MESHWorksAPQP.Management.Command.Setup.UserManagement.GetUserManagementCommand&gt;" />
    public class GetUserManagementHandler : ICommandHandler<GetUserManagementCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IUserManagementManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserManagementHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetUserManagementHandler(IUserManagementManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetUserManagementCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}
