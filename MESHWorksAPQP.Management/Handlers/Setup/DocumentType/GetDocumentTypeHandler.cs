// <copyright file="GetDocumentTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>
namespace MESHWorksAPQP.Management.Handlers.Setup.DocumentType
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.DocumentType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.DocumentType;

    /// <summary>
    /// Class GetCommodityHandler.
    /// </summary>
    public class GetDocumentTypeHandler : ICommandHandler<GetDocumentTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IDocumentTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDocumentTypeHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetDocumentTypeHandler(IDocumentTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetDocumentTypeCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}
