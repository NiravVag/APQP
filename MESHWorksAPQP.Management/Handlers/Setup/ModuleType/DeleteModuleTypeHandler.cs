// <copyright file="DeleteModuleTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.ModuleType
{

    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.ModuleType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.ModuleType;

    /// <summary>
    /// Class DeleteModuleTypeHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler&lt;MESHWorksAPQP.Management.Command.Setup.ModuleType.DeleteModuleTypeCommand&gt;" />
    public class DeleteModuleTypeHandler : ICommandHandler<DeleteModuleTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IModuleTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteModuleTypeHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public DeleteModuleTypeHandler(IModuleTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DeleteModuleTypeCommand command)
        {
            command.Result = await this.manager.Delete(command.Id);
        }
    }
}
