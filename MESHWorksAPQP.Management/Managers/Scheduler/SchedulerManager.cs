// <copyright file="SchedulerManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Managers.Scheduler
{
    using System.Threading.Tasks;
    using EmailProvider.Interface.Managers;
    using MESHWorksAPQP.Management.Interface.Managers.Scheduler;

    /// <summary>
    /// Class SchedulerManager.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Managers.Scheduler.ISchedulerManager" />
    public class SchedulerManager : ISchedulerManager
    {
        /// <summary>
        /// The email manager.
        /// </summary>
        private readonly IEmailManager emailManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchedulerManager" /> class.
        /// </summary>
        /// <param name="emailManager">The email manager.</param>
        public SchedulerManager(IEmailManager emailManager)
        {
            this.emailManager = emailManager;
        }

        /// <summary>
        /// Processes the email.
        /// </summary>
        /// <returns>
        /// Task.
        /// </returns>
        public async Task<bool> ProcessEmail()
        {
            await this.emailManager.ProcessEmail();
            return true;
        }
    }
}
