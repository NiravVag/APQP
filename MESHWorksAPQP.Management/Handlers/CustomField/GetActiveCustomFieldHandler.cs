// <copyright file="GetActiveCustomFieldHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.CustomField
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.CustomField;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.CustomField;

    /// <summary>
    /// Class GetActiveCustomFieldHandler.
    /// </summary>
    /// <seealso cref="ICommandHandler{GetCustomFieldCommand}" />
    public class GetActiveCustomFieldHandler : ICommandHandler<GetActiveCustomFieldCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICustomFieldManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetActiveCustomFieldHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetActiveCustomFieldHandler(ICustomFieldManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetActiveCustomFieldCommand command)
        {
            command.Result = await this.manager.GetCustomFields(command);
        }
    }
}