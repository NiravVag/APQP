// <copyright file="SavePageTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.PageType
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.PageType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.PageType;

    /// <summary>
    /// Class SavePageTypeHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Setup.SavePageTypeCommand}" />
    public class SavePageTypeHandler : ICommandHandler<SavePageTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IPageTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavePageTypeHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SavePageTypeHandler(IPageTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SavePageTypeCommand command)
        {
            command.Result = await this.manager.Save(command);
        }
    }
}
