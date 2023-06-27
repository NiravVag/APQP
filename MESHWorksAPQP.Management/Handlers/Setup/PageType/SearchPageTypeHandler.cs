// <copyright file="SearchPageTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.PageType
{
    using MESHWorksAPQP.Management.Command.Setup.PageType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.PageType;
    using System.Threading.Tasks;

    /// <summary>
    /// Class SearchPageTypeHandler.
    /// </summary>
    public class SearchPageTypeHandler : ICommandHandler<SearchPageTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IPageTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchPageTypeHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SearchPageTypeHandler(IPageTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SearchPageTypeCommand command)
        {
            command.Result = await this.manager.Search(command);
        }
    }
}
