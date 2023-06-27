// <copyright file="DeleteCommodityHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.Commodity
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Commodity;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Commodity;

    /// <summary>
    /// Class DeleteCommodityHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler&lt;MESHWorksAPQP.Management.Command.Setup.Commodity.DeleteCommodityCommand&gt;" />
    public class DeleteCommodityHandler : ICommandHandler<DeleteCommodityCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICommodityManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCommodityHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public DeleteCommodityHandler(ICommodityManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DeleteCommodityCommand command)
        {
            command.Result = await this.manager.Delete(command.Id);
        }
    }
}
