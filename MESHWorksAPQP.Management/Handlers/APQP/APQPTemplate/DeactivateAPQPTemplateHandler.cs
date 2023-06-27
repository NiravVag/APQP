// <copyright file="DeactivateAPQPTemplateHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.APQP.APQPTemplate
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.APQP.APQPTemplate;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;

    /// <summary>
    /// Class DeactivateAPQPTemplateHandler.
    /// </summary>
    /// <seealso cref="ICommandHandler{Commands.APQP.APQPTemplate.DeactivateAPQPTemplateCommand};" />
    public class DeactivateAPQPTemplateHandler : ICommandHandler<DeactivateAPQPTemplateCommand>
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly IAPQPTemplateManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeactivateAPQPTemplateHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public DeactivateAPQPTemplateHandler(IAPQPTemplateManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DeactivateAPQPTemplateCommand command)
        {
            command.Result = await this.manager.DeactivateAPQPTemplate(command);
        }
    }
}
