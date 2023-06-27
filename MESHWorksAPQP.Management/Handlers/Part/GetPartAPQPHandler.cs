// <copyright file="GetPartAPQPHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Part
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Part;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Part;

    /// <summary>
    /// Class GetPartAPQPHandler.
    /// </summary>
    public class GetPartAPQPHandler : ICommandHandler<GetPartAPQPCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IPartManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPartAPQPHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetPartAPQPHandler(IPartManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetPartAPQPCommand command)
        {
            command.Result = await this.manager.GetPartAPQP(command);
        }
    }
}
