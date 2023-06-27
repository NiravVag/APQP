// <copyright file="GetMaterialTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>
namespace MESHWorksAPQP.Management.Handlers.Setup
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.MaterialType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.MaterialType;

    /// <summary>
    /// Class GetMaterialTypeHandler.
    /// </summary>
    public class GetMaterialTypeHandler : ICommandHandler<GetMaterialTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IMaterialTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMaterialTypeHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetMaterialTypeHandler(IMaterialTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetMaterialTypeCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}
