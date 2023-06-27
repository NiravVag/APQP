// <copyright file="SearchAPQPDocumentHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.APQP
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.APQP;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;

    /// <summary>
    /// SearchAPQPDocumentHandler
    /// </summary>
    public class SearchAPQPDocumentHandler : ICommandHandler<SearchAPQPDocumentCommand>
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly IAPQPManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchAPQPDocumentHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SearchAPQPDocumentHandler(IAPQPManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>
        /// Task.
        /// </returns>

        public async Task Execute(SearchAPQPDocumentCommand command)
        {
            command.Result = await this.manager.GetAPQPDocument(command);
        }
    }
}
