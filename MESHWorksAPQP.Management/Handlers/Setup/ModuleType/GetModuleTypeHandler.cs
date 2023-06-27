// <copyright file="GetModuleTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.ModuleType
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.ModuleType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.ModuleType;


    /// <summary>
    /// Class GetModuleTypeHandler.
    /// </summary>
    public class GetModuleTypeHandler : ICommandHandler<GetModuleTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IModuleTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetModuleTypeHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetModuleTypeHandler(IModuleTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetModuleTypeCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}
