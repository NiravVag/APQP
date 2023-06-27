// <copyright file="SaveCompanyUserTypeHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Role.CompanyUserType
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Role.CompanyUserType;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Role;

    /// <summary>
    /// Class SaveCompanyUserTypeHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.Company.CompanyUserType.SaveCompanyUserTypeCommand}" />
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Commands.CompanyUserType.SaveCompanyUserTypeCommand}" />
    public class SaveCompanyUserTypeHandler : ICommandHandler<SaveCompanyUserTypeCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ICompanyUserTypeManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveCompanyUserTypeHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SaveCompanyUserTypeHandler(ICompanyUserTypeManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SaveCompanyUserTypeCommand command)
        {
            command.Result = await this.manager.Save(command);
        }
    }
}
