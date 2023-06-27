// <copyright file="GetCustomFieldPropertiesOverrideHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.CustomField.CustomFieldPropertiesOverride
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.CustomField.CustomFieldPropertiesOverride;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.CustomField;

    /// <summary>
    /// Class GetCustomFieldPropertiesOverrideHandler.
    /// </summary>
    /// <seealso cref="ICommandHandler{GetCustomFieldPropertiesOverrideCommand}" />
    public class GetCustomFieldPropertiesOverrideHandler : ICommandHandler<GetCustomFieldPropertiesOverrideCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICustomFieldPropertiesOverrideManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCustomFieldPropertiesOverrideHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetCustomFieldPropertiesOverrideHandler(ICustomFieldPropertiesOverrideManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetCustomFieldPropertiesOverrideCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}
