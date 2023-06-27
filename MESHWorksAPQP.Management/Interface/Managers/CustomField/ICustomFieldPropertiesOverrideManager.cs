// <copyright file="ICustomFieldPropertiesOverrideManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.CustomField
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.CustomField.CustomFieldPropertiesOverride;
    using MESHWorksAPQP.Management.ViewModel.CustomField;

    /// <summary>
    /// ICustomFieldPropertiesOverrideManager.
    /// </summary>
    public interface ICustomFieldPropertiesOverrideManager
    {
        /// <summary>
        /// Gets the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The CustomFieldPropertiesOverrideVM.</returns>
        Task<CustomFieldPropertiesOverrideVM> Get(GetCustomFieldPropertiesOverrideCommand command);

        /// <summary>
        /// Saves the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The CustomFieldPropertiesOverrideVM.</returns>
        Task<CustomFieldPropertiesOverrideVM> Save(SaveCustomFieldPropertiesOverrideCommand command);
    }
}
