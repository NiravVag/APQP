// <copyright file="DeleteAPQPDiscussionHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.APQP.APQPDiscussion
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.APQP.APQPDiscussion;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;

    /// <summary>
    /// Class DeleteAPQPDiscussionHandler.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler{MESHWorksAPQP.Management.Command.APQP.APQPDiscussion.DeleteAPQPDiscussionCommand}" />
    public class DeleteAPQPDiscussionHandler : ICommandHandler<DeleteAPQPDiscussionCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IAPQPDiscussionManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAPQPDiscussionHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public DeleteAPQPDiscussionHandler(IAPQPDiscussionManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(DeleteAPQPDiscussionCommand command)
        {
            command.Result = await this.manager.Delete(command);
        }
    }
}
