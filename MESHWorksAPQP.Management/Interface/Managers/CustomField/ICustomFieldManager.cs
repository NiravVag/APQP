// <copyright file="ICustomFieldManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.CustomField
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.CustomField;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.CustomField;
    using MESHWorksAPQP.Repository.CustomModel.CustomField;

    /// <summary>
    /// Interface ILocationManager.
    /// </summary>
    public interface ICustomFieldManager
    {
        /// <summary>
        /// Searches the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Page of LocationListVM.</returns>
        Task<Page<CustomFieldListVM>> Search(SearchCustomFieldCommand command);

        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// LocationVM.
        /// </returns>
        Task<CustomFieldVM> Get(GetCustomFieldCommand command);

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// LocationVM.
        /// </returns>
        Task<CustomFieldVM> Save(SaveCustomFieldCommand command);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// bool.
        /// </returns>
        Task<bool> Delete(DeleteCustomFieldCommand command);

        /// <summary>
        /// Gets the custom fields.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// List of CustomFieldCM.
        /// </returns>
        Task<IList<CustomFieldCM>> GetCustomFields(GetActiveCustomFieldCommand command);
    }
}
