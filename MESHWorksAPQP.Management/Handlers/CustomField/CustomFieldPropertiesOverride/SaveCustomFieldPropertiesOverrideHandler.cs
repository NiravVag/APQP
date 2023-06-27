// <copyright file="SaveCustomFieldPropertiesOverrideHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.CustomField.CustomFieldPropertiesOverride
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.CustomField.CustomFieldPropertiesOverride;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.CustomField;

    /// <summary>
    /// Class SaveCustomFieldPropertiesOverrideHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler&lt;MESHWorksAPQP.Management.Command.CustomField.CustomFieldPropertiesOverride.SaveCustomFieldPropertiesOverrideCommand&gt;" />
    public class SaveCustomFieldPropertiesOverrideHandler : ICommandHandler<SaveCustomFieldPropertiesOverrideCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICustomFieldPropertiesOverrideManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveCustomFieldPropertiesOverrideHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SaveCustomFieldPropertiesOverrideHandler(ICustomFieldPropertiesOverrideManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SaveCustomFieldPropertiesOverrideCommand command)
        {
            command.Result = await this.manager.Save(command);
        }
    }
}
