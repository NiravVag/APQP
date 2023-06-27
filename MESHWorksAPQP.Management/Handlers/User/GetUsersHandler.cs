// <copyright file="GetUsersHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.User
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.User;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.User;

    /// <summary>
    /// Class GetUsersHandler.
    /// </summary>
    public class GetUsersHandler : ICommandHandler<GetUsersCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IUserManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUsersHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetUsersHandler(IUserManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetUsersCommand command)
        {
            command.Result = await this.manager.GetUserList(command);
        }
    }
}
