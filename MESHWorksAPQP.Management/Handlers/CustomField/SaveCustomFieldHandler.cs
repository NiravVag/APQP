// <copyright file="SaveCustomFieldHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.CustomField
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.CustomField;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.CustomField;

    /// <summary>
    /// Class SaveLocationHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Location.SaveLocationCommand}" />
    public class SaveCustomFieldHandler : ICommandHandler<SaveCustomFieldCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICustomFieldManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveCustomFieldHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SaveCustomFieldHandler(ICustomFieldManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SaveCustomFieldCommand command)
        {
            command.Result = await this.manager.Save(command);
        }
    }
}
