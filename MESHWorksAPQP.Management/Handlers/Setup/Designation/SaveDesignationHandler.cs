// <copyright file="SaveDesignationHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.Designation
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.Designation;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.Designation;

    /// <summary>
    /// Class SaveDesignationHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{SaveDesignationCommand}" />
    public class SaveDesignationHandler : ICommandHandler<SaveDesignationCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IDesignationManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveDesignationHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SaveDesignationHandler(IDesignationManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SaveDesignationCommand command)
        {
            command.Result = await this.manager.Save(command);
        }
    }
}
