// <copyright file="SearchCustomFieldHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.RFQHandler.Quote
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.CustomField;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.CustomField;

    /// <summary>
    /// Class SearchCustomFieldHandler.
    /// </summary>
    public class SearchCustomFieldHandler : ICommandHandler<SearchCustomFieldCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICustomFieldManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCustomFieldHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SearchCustomFieldHandler(ICustomFieldManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SearchCustomFieldCommand command)
        {
            command.Result = await this.manager.Search(command);
        }
    }
}
