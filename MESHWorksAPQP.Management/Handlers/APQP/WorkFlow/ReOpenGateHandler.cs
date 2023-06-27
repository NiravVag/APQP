// <copyright file="ReOpenGateHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.APQP.WorkFlow
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.APQP.WorkFlow;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;

    /// <summary>
    /// Class ReOpenGateHandler.
    /// </summary>
    public class ReOpenGateHandler : ICommandHandler<ReOpenGateCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IWorkFlowManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReOpenGateHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public ReOpenGateHandler(IWorkFlowManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(ReOpenGateCommand command)
        {
            command.Result = await this.manager.ReOpenGate(command);
        }
    }
}
