// <copyright file="IGateManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.APQP
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.APQP;
    using MESHWorksAPQP.Management.ViewModel.APQP;
    using MESHWorksAPQP.Management.ViewModel.APQP.Gates;

    /// <summary>
    /// Interface IGateManager.
    /// </summary>
    public interface IGateManager
    {
        /// <summary>
        /// Gets the specified get Gate command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>GateVM.</returns>
        Task<GateVM> Get(GetGateCommand command);

        /// <summary>
        /// Deletes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>bool.</returns>
        Task<bool> Delete(DeleteGateCommand command);

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>GateVM.</returns>
        Task<GateVM> Save(SaveGateCommand command);

        /// <summary>
        /// Checks the gate name exists.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="templateId">The template identifier.</param>
        /// <param name="gateId">The gate identifier.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="apqpTemplate">The apqp template.</param>
        /// <returns>bool.</returns>
        Task<bool> CheckGateNameExists(string name, Guid templateId, Guid? gateId, int sortOrder, APQPTemplateVM apqpTemplate);

        /// <summary>
        /// Sets the get code.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>string.</returns>
        Task<string> SetGetCode(string name);
    }
}
