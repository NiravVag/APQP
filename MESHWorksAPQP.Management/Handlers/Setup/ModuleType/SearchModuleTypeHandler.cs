// <copyright file="SearchModuleTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>
namespace MESHWorksAPQP.Management.Handlers.Setup.ModuleType
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.ModuleType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.ModuleType;

    /// <summary>
    /// Class SearchModuleTypeHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler&lt;MESHWorksAPQP.Management.Command.Setup.ModuleType.SearchModuleTypeCommand&gt;" />
    public class SearchModuleTypeHandler : ICommandHandler<SearchModuleTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IModuleTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchModuleTypeHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SearchModuleTypeHandler(IModuleTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SearchModuleTypeCommand command)
        {
            command.Result = await this.manager.Search(command);
        }
    }
}
