// <copyright file="SearchCompanyModuleHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Role.CompanyModule
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Role.CompanyModule;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Role;

    /// <summary>
    /// Class SearchCompanyModuleHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Role.CompanyModule.SearchCompanyModuleCommand}" />
    public class SearchCompanyModuleHandler : ICommandHandler<SearchCompanyModuleCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICompanyModuleManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCompanyModuleHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SearchCompanyModuleHandler(ICompanyModuleManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SearchCompanyModuleCommand command)
        {
            command.Result = await this.manager.Search(command);
        }
    }
}