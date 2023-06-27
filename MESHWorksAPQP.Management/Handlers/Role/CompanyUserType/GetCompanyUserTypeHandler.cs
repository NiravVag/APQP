// <copyright file="GetCompanyUserTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Role.CompanyUserType
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Role.CompanyUserType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Role;

    /// <summary>
    /// Class GetCompanyUserTypeHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Company.CompanyUserType.GetCompanyUserTypeCommand}" />
    /// <seealso cref="ICommandHandler{GetCompanyUserTypeCommand}" />
    public class GetCompanyUserTypeHandler : ICommandHandler<GetCompanyUserTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICompanyUserTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCompanyUserTypeHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetCompanyUserTypeHandler(ICompanyUserTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetCompanyUserTypeCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}