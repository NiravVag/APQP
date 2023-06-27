// <copyright file="GateClosureHandler.cs" company="MESHWorksAPQP">
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
    /// Class SendGateClosureEmailHandler.
    /// </summary>
    public class GateClosureHandler : ICommandHandler<GateClosureCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IWorkFlowManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GateClosureHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GateClosureHandler(IWorkFlowManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GateClosureCommand command)
        {
            if (command.Entity.ClouserType == ClouserType.Email)
            {
                command.Result = await this.manager.SendGateClosureEmail(command);
            }
            else if (command.Entity.ClouserType == ClouserType.Document)
            {
                command.Result = await this.manager.SaveGateClosureDocument(command);
            }
            else if (command.Entity.ClouserType == ClouserType.Approval)
            {
                command.Result = await this.manager.SaveGateClosureApproverAction(command);
            }
        }
    }
}
