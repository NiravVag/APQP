// <copyright file="SaveModuleTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>
namespace MESHWorksAPQP.Management.Handlers.Setup.ModuleType
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.ModuleType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.ModuleType;

    /// <summary>
    /// Class SaveModuleTypeHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Company.SaveCompanyCommand}" />
    public class SaveModuleTypeHandler : ICommandHandler<SaveModuleTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IModuleTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveModuleTypeHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SaveModuleTypeHandler(IModuleTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SaveModuleTypeCommand command)
        {
            command.Result = await this.manager.Save(command);
        }
    }
}
