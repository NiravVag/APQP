// <copyright file="GetGroupedLookupHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Lookup
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Lookup;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Lookup;

    /// <summary>
    /// Class GetGroupedLookupHandler.
    /// </summary>
    public class GetGroupedLookupHandler : ICommandHandler<GetGroupedLookupCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ILookupManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetGroupedLookupHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetGroupedLookupHandler(ILookupManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetGroupedLookupCommand command)
        {
            command.Result = await this.manager.GetGroupedLookup(command.Filters);
        }
    }
}