// <copyright file="SaveMaterialTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.MaterialType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.MaterialType;

    /// <summary>
    /// Class SaveProcessHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Setup.SaveMaterialTypeCommand}" />
    public class SaveMaterialTypeHandler : ICommandHandler<SaveMaterialTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IMaterialTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveMaterialTypeHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SaveMaterialTypeHandler(IMaterialTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SaveMaterialTypeCommand command)
        {
            command.Result = await this.manager.Save(command);
        }
    }
}
