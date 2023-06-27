// <copyright file="SearchAPQPTemplateHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Part
{
    using System;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Part;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Part;



    /// <summary>
    /// Class SearchAPQPTemplateHandler.
    /// </summary>
    public class SearchPartDocumentHandler : ICommandHandler<SearchPartDocumentCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IPartManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchPartDocumentHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SearchPartDocumentHandler(IPartManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SearchPartDocumentCommand command)
        {
            command.Result = await this.manager.GetPartDocument(command);
        }
    }
}