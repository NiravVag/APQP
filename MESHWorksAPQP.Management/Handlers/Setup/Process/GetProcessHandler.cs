// <copyright file="GetProcessHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>
namespace MESHWorksAPQP.Management.Handlers.Setup
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Process;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Process;

    /// <summary>
    /// Class GetProcessHandler.
    /// </summary>
    public class GetProcessHandler : ICommandHandler<GetProcessCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IProcessManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProcessHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetProcessHandler(IProcessManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetProcessCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}
