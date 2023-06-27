// <copyright file="RequestGateClosureApprovalHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.APQP.WorkFlow
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.APQP.WorkFlow;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;

    /// <summary>
    /// Class RequestGateClosureApprovalHandler.
    /// </summary>
    public class RequestGateClosureApprovalHandler : ICommandHandler<RequestGateClosureApprovalCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IWorkFlowManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestGateClosureApprovalHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public RequestGateClosureApprovalHandler(IWorkFlowManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(RequestGateClosureApprovalCommand command)
        {
            command.Result = await this.manager.RequestGateClosureApprovalCommand(command);
        }
    }
}
