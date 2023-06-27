// <copyright file="IAPQPTemplateManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.APQP
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.APQP.APQPTemplate;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.APQP;
    using MESHWorksAPQP.Management.ViewModel.APQP.APQPTemplate;

    /// <summary>
    /// Interface IAPQPTemplateManager.
    /// </summary>
    public interface IAPQPTemplateManager
    {
        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of APQPListVM.</returns>
        Task<Page<APQPTemplateListVM>> Search(SearchAPQPTemplateCommand command);

        /// <summary>
        /// Gets the specified get APQP command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>APQPTemplateVM.</returns>
        Task<APQPTemplateVM> Get(GetAPQPTemplateCommand command);

        /// <summary>
        /// Deletes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>bool.</returns>
        Task<bool> Delete(DeleteAPQPTemplateCommand command);

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>APQPTemplateVM.</returns>
        Task<APQPTemplateVM> Save(SaveAPQPTemplateCommand command);

        /// <summary>
        /// Clones the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Guid.</returns>
        Task<Guid> Clone(CloneAPQPTemplateCommand command);

        /// <summary>
        /// Apqps the template validation.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>List of String.</returns>
        Task<List<string>> APQPTemplateValidation(APQPTemplateValidationCommand command);

        /// <summary>
        /// Deactivates the apqp template.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>bool.</returns>
        Task<bool> DeactivateAPQPTemplate(DeactivateAPQPTemplateCommand command);
    }
}
