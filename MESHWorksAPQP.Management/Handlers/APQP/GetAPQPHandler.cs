// <copyright file="GetAPQPHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.APQP
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.APQP;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;

    /// <summary>
    /// Class GetAPQPDataHandler.
    /// </summary>
    public class GetAPQPHandler : ICommandHandler<GetAPQPCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IAPQPManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAPQPHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetAPQPHandler(IAPQPManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetAPQPCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}
