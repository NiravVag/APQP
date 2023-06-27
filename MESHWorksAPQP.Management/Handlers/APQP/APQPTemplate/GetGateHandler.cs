// <copyright file="GetGateHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.APQP
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.APQP;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;

    /// <summary>
    /// class GetGateHandler.
    /// </summary>
    public class GetGateHandler : ICommandHandler<GetGateCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IGateManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetGateHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetGateHandler(IGateManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetGateCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}
