// <copyright file="SearchUserManagementHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.UserManagement
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.UserManagement;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.UserManagement;

    /// <summary>
    /// Class SearchUserManagementHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler&lt;MESHWorksAPQP.Management.Command.Setup.UserManagement.SearchUserManagementCommand&gt;" />
    public class SearchUserManagementHandler : ICommandHandler<SearchUserManagementCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IUserManagementManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchUserManagementHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SearchUserManagementHandler(IUserManagementManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SearchUserManagementCommand command)
        {
            command.Result = await this.manager.Search(command);
        }
    }
}
