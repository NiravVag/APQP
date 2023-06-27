// <copyright file="DeleteDesignationHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.Designation
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Designation;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Designation;

    /// <summary>
    /// Class DeleteDesignationHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{DeleteDesignationCommand}" />
    public class DeleteDesignationHandler : ICommandHandler<DeleteDesignationCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IDesignationManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteDesignationHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public DeleteDesignationHandler(IDesignationManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DeleteDesignationCommand command)
        {
            command.Result = await this.manager.Delete(command.Id);
        }
    }
}
