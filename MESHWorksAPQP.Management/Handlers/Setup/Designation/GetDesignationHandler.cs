// <copyright file="GetDesignationHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.Designation
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Designation;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Designation;

    /// <summary>
    /// Class GetDesignationHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{GetDesignationCommand}" />
    public class GetDesignationHandler : ICommandHandler<GetDesignationCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IDesignationManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDesignationHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetDesignationHandler(IDesignationManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetDesignationCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}
