// <copyright file="IAPQPManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.APQP
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.APQP;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.APQP.Gates;
    using MESHWorksAPQP.Repository.CustomModel.APQP;

    /// <summary>
    /// Interface IAPQPManager.
    /// </summary>
    public interface IAPQPManager
    {
        /// <summary>
        /// Gets the specified get APQP command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>APQPTemplateVM.</returns>
        Task<APQPCM> Get(GetAPQPCommand command);

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>APQPTemplateVM.</returns>
        Task<GateDataVM> Save(SaveAPQPCommand command);

        /// <summary>
        /// Saves the apqp project.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>APQPProjectCM.</returns>
        Task<APQPProjectCM> SaveAPQPProject(SaveAPQPProjectCommand command);


        /// <summary>
        /// Deletes the apqp project.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>bool</returns>
        Task<bool> DeleteAPQPProject(DeleteAPQPProjectCommand command);

        /// <summary>
        /// Deletes the apqp project.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="referanceId">The referanceId.</param>
        /// <returns>bool</returns>
        Task<List<DocumentAttachmentCM>> GetDocumentData(Guid id, Guid referanceId);

        /// <summary>
        /// Gets the apqp document.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>SearchAPQPCDocument Command</returns>
        Task<Page<APQPPartDocumentCM>> GetAPQPDocument(SearchAPQPDocumentCommand command);
    }
}
