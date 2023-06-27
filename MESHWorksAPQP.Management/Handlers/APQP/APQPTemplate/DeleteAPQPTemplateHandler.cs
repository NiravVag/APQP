// <copyright file="DeleteAPQPTemplateHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.APQP
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.APQP.APQPTemplate;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;

    /// <summary>
    /// Class DeleteAPQPTemplateHandler.
    /// </summary>
    public class DeleteAPQPTemplateHandler : ICommandHandler<DeleteAPQPTemplateCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IAPQPTemplateManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAPQPTemplateHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public DeleteAPQPTemplateHandler(IAPQPTemplateManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DeleteAPQPTemplateCommand command)
        {
            command.Result = await this.manager.Delete(command);
        }
    }
}