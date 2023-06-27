// <copyright file="SaveEmailNotificationHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Setup.EmailNotification
{
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Setup.EmailNotification;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Setup.EmailNotification;

    /// <summary>
    /// Class SaveEmailNotificationHandler.
    /// </summary>
    public class SaveEmailNotificationHandler : ICommandHandler<SaveEmailNotificationCommand>
    {
        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IEmailNotificationManager manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveEmailNotificationHandler"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public SaveEmailNotificationHandler(IEmailNotificationManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task.</returns>
        public async Task Execute(SaveEmailNotificationCommand command)
        {
            command.Result = await this.manager.Save(command);
        }
    }
}
