// <copyright file="GetPartRelationsHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Part
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Part;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Part;

    /// <summary>
    /// Class GetPartHandler.
    /// </summary>
    public class GetPartRelationsHandler : ICommandHandler<GetPartRelationsCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IPartManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPartRelationsHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetPartRelationsHandler(IPartManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetPartRelationsCommand command)
        {
            command.Result = await this.manager.GetPartRelations(command);
        }
    }
}
