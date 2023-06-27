// <copyright file="SaveCustomFieldPropertiesOverrideCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.CustomField.CustomFieldPropertiesOverride
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.CustomField;

    /// <summary>
    /// Class SaveCustomFieldPropertiesOverrideCommand.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.ISaveCommand{MESHWorksAPQP.Management.ViewModel.CustomField.CustomFieldPropertiesOverrideVM}" />
    public class SaveCustomFieldPropertiesOverrideCommand : ISaveCommand<CustomFieldPropertiesOverrideVM>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public CustomFieldPropertiesOverrideVM Entity { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public CustomFieldPropertiesOverrideVM Result { get; set; }
    }
}
