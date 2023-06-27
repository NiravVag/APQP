// <copyright file="DeleteProcessHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Process;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Process;

    /// <summary>
    /// Class DeleteProcessHandler.
    /// </summary>
    public class DeleteProcessHandler : ICommandHandler<DeleteProcessCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IProcessManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteProcessHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public DeleteProcessHandler(IProcessManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DeleteProcessCommand command)
        {
            command.Result = await this.manager.Delete(command.Id);
        }
    }
}
