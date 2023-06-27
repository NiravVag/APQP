// <copyright file="GetPageTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.PageType
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.PageType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.PageType;

    /// <summary>
    /// Class GetPageTypeHandler.
    /// </summary>
    public class GetPageTypeHandler : ICommandHandler<GetPageTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IPageTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPageTypeHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetPageTypeHandler(IPageTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetPageTypeCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}
