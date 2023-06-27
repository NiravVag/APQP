// <copyright file="GetLookupHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Lookup
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Lookup;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Lookup;

    /// <summary>
    /// Class GetLookupHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Lookup.GetLookupCommand}" />
    public class GetLookupHandler : ICommandHandler<GetLookupCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ILookupManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLookupHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetLookupHandler(ILookupManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetLookupCommand command)
        {
            command.Result = await this.manager.GetLookups(command.Filters);
        }
    }
}
