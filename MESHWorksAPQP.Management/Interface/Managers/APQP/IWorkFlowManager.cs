// <copyright file="IWorkFlowManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.APQP
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.APQP.WorkFlow;
    using MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow;

    /// <summary>
    /// Interface IWorkFlowManager.
    /// </summary>
    public interface IWorkFlowManager
    {
        /// <summary>
        /// Sends the gate closure email.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>GateClosureSettingVM.</returns>
        Task<GateClosureSettingVM> SendGateClosureEmail(GateClosureCommand command);

        /// <summary>
        /// Saves the gate closure document.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>GateClosureSettingVM.</returns>
        Task<GateClosureSettingVM> SaveGateClosureDocument(GateClosureCommand command);

        /// <summary>
        /// Gets the gate closure status.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>GateClouserVM.</returns>
        Task<List<GateClouserVM>> GetGateClosureStatus(GetGateClosureStatusCommand command);

        /// <summary>
        /// Updates the active gate identifier.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>bool.</returns>
        Task<bool> UpdateActiveGateId(UpdateActiveGateIdCommand command);

        /// <summary>
        /// Updates the apqp status.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        Task<bool> UpdateStatus(UpdateGateStatusCommand command);

        /// <summary>
        /// Saves the gate closure approver action.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>ApproverActionVM.</returns>
        Task<GateClosureSettingVM> SaveGateClosureApproverAction(GateClosureCommand command);

        /// <summary>
        /// Sends the gate closure approval request.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>bool.</returns>
        Task<bool> RequestGateClosureApprovalCommand(RequestGateClosureApprovalCommand command);

        /// <summary>
        /// Reopen gate
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> ReOpenGate(ReOpenGateCommand command);
    }
}
