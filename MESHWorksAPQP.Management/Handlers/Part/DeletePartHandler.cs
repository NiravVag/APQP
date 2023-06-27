// <copyright file="DeletePartHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Part
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Part;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Part;

    /// <summary>
    /// Class DeletePartHandler.
    /// </summary>
    public class DeletePartHandler : ICommandHandler<DeletePartCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IPartManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeletePartHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public DeletePartHandler(IPartManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DeletePartCommand command)
        {
            command.Result = await this.manager.Delete(command);
        }
    }
}
