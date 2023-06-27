// <copyright file="SearchCommodityHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.Commodity
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Commodity;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Commodity;

    /// <summary>
    /// Class SearchCommodityHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler&lt;MESHWorksAPQP.Management.Command.Setup.Commodity.SearchCommodityCommand&gt;" />
    public class SearchCommodityHandler : ICommandHandler<SearchCommodityCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICommodityManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCommodityHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SearchCommodityHandler(ICommodityManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SearchCommodityCommand command)
        {
            command.Result = await this.manager.Search(command);
        }
    }
}
