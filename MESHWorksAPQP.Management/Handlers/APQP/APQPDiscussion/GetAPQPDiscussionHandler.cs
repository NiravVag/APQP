// <copyright file="GetAPQPDiscussionHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.APQP.APQPDiscussion
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.APQP.APQPDiscussion;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.APQP;

    /// <summary>
    /// Class GetAPQPDiscussionHandler.
    /// </summary>
    public class GetAPQPDiscussionHandler : ICommandHandler<GetAPQPDiscussionCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IAPQPDiscussionManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAPQPDiscussionHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GetAPQPDiscussionHandler(IAPQPDiscussionManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetAPQPDiscussionCommand command)
        {
            command.Result = await this.manager.Get(command);
        }
    }
}
