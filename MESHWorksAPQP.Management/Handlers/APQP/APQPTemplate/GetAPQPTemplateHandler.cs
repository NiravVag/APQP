// <copyright file="GetAPQPTemplateHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.APQP
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.APQP.APQPTemplate;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;

    /// <summary>
    /// Class GetAPQPTemplateHandler.
    /// </summary>
    public class GetAPQPTemplateHandler : ICommandHandler<GetAPQPTemplateCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IAPQPTemplateManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAPQPTemplateHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetAPQPTemplateHandler(IAPQPTemplateManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetAPQPTemplateCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}
