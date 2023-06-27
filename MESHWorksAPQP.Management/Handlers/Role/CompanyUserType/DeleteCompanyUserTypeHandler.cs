// <copyright file="DeleteCompanyUserTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Role.CompanyUserType
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Role.CompanyUserType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Role;

    /// <summary>
    /// Class DeleteCompanyUserTypeHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Company.CompanyUserType.DeleteCompanyUserTypeCommand}" />
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.CompanyUserType.DeleteCompanyUserTypeCommand}" />
    public class DeleteCompanyUserTypeHandler : ICommandHandler<DeleteCompanyUserTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICompanyUserTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCompanyUserTypeHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public DeleteCompanyUserTypeHandler(ICompanyUserTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DeleteCompanyUserTypeCommand command)
        {
            command.Result = await this.manager.Delete(command);
        }
    }
}
