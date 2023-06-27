// <copyright file="SearchDesignationHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.Designation
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Designation;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Designation;

    /// <summary>
    /// Class SearchDesignationHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{SearchDesignationCommand}" />
    public class SearchDesignationHandler : ICommandHandler<SearchDesignationCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IDesignationManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchDesignationHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SearchDesignationHandler(IDesignationManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SearchDesignationCommand command)
        {
            command.Result = await this.manager.Search(command);
        }
    }
}
