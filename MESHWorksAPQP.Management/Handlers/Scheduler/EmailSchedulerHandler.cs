// <copyright file="EmailSchedulerHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Scheduler
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Commands.Scheduler;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Scheduler;

    /// <summary>
    /// Class EmailSchedulerHandler.
    /// </summary>
    public class EmailSchedulerHandler : ICommandHandler<EmailSchedulerCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly ISchedulerManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSchedulerHandler" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public EmailSchedulerHandler(ISchedulerManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(EmailSchedulerCommand command)
        {
            command.Result = await this.manager.ProcessEmail();
        }
    }
}
