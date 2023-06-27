﻿// <copyright file="SaveCommodityHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.Commodity
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Commodity;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Commodity;

    /// <summary>
    /// Class SaveCommodityHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Company.SaveCompanyCommand}" />
    public class SaveCommodityHandler : ICommandHandler<SaveCommodityCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICommodityManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveCommodityHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SaveCommodityHandler(ICommodityManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SaveCommodityCommand command)
        {
            command.Result = await this.manager.Save(command);
        }
    }
}
