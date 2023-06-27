// <copyright file="UpdateActiveGateIdHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.APQP.WorkFlow
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.APQP.WorkFlow;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// Class UpdateActiveGateIdHandler.
    /// </summary>
    public class UpdateGateStatusHandler : ICommandHandler<UpdateGateStatusCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IWorkFlowManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateGateStatusHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public UpdateGateStatusHandler(IWorkFlowManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(UpdateGateStatusCommand command)
        {

            command.Result = await this.manager.UpdateStatus(command);
        }
    }
}
