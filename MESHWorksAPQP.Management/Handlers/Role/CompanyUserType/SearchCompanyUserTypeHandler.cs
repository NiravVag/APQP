// <copyright file="SearchCompanyUserTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Role.CompanyUserType
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Role.CompanyUserType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Role;

    /// <summary>
    /// Class SearchCompanyUserTypeHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Company.CompanyUserType.SearchCompanyUserTypeCommand}" />
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.CompanyUserType.SearchCompanyUserTypeCommand}" />
    public class SearchCompanyUserTypeHandler : ICommandHandler<SearchCompanyUserTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICompanyUserTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCompanyUserTypeHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SearchCompanyUserTypeHandler(ICompanyUserTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SearchCompanyUserTypeCommand command)
        {
            command.Result = await this.manager.Search(command);
        }
    }
}