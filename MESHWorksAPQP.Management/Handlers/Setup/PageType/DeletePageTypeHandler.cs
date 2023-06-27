// <copyright file="DeletePageTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.PageType
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.PageType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.PageType;

    /// <summary>
    /// Class DeletePageTypeHandler.
    /// </summary>
    public class DeletePageTypeHandler : ICommandHandler<DeletePageTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IPageTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeletePageTypeHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public DeletePageTypeHandler(IPageTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DeletePageTypeCommand command)
        {
            command.Result = await this.manager.Delete(command.Id);
        }
    }
}
