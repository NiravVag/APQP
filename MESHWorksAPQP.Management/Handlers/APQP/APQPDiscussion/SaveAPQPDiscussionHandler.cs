// <copyright file="SaveAPQPDiscussionHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.APQP
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.APQP.APQPDiscussion;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;

    /// <summary>
    /// Class SaveAPQPDiscussionHandler.
    /// </summary>
    public class SaveAPQPDiscussionHandler : ICommandHandler<SaveAPQPDiscussionCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IAPQPDiscussionManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveAPQPDiscussionHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SaveAPQPDiscussionHandler(IAPQPDiscussionManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SaveAPQPDiscussionCommand command)
        {
            command.Result = await this.manager.Save(command);
        }
    }
}
