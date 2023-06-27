//// <copyright file="SaveGateClosureApproverActionHandler.cs" company="MESHWorksAPQP">
//// Copyright (c) MESHWorksAPQP. All rights reserved.
//// </copyright>

//namespace MESHWorksAPQP.Management.Handlers.APQP.WorkFlow
//{
//    using System.Threading.Tasks;
//    using MESHWorksAPQP.Management.Command.APQP.WorkFlow;
//    using MESHWorksAPQP.Management.Interface.Handlers;
//    using MESHWorksAPQP.Management.Interface.Managers.APQP;
//    using MESHWorksAPQP.Shared.Enum;

//    /// <summary>
//    /// Class SaveGateClosureApproverActionHandler.
//    /// </summary>
//    public class SaveGateClosureApproverActionHandler : ICommandHandler<SaveGateClosureApproverActionCommand>
//    {
//        /// <summary>
//        /// The manager.
//        /// </summary>
//        private readonly IWorkFlowManager manager;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="SaveGateClosureApproverActionHandler"/> class.
//        /// </summary>
//        /// <param name="manager">The manager.</param>
//        public SaveGateClosureApproverActionHandler(IWorkFlowManager manager)
//        {
//            this.manager = manager;
//        }

//        /// <summary>
//        /// Executes the specified command.
//        /// </summary>
//        /// <param name="command">The command.</param>
//        /// <returns>Task.</returns>
//        public async Task Execute(SaveGateClosureApproverActionCommand command)
//        {
//            command.Result = await this.manager.SaveGateClosureApproverAction(command);
//        }
//    }
//}
