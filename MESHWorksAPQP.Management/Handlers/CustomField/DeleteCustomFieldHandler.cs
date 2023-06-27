// <copyright file="DeleteCustomFieldHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.CustomField
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.CustomField;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.CustomField;

    /// <summary>
    /// Class DeleteCustomFieldHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.CustomField.DeleteLocationCommand}" />
    public class DeleteCustomFieldHandler : ICommandHandler<DeleteCustomFieldCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICustomFieldManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCustomFieldHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public DeleteCustomFieldHandler(ICustomFieldManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DeleteCustomFieldCommand command)
        {
            command.Result = await this.manager.Delete(command);
        }
    }
}
