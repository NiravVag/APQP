// <copyright file="ISchedulerManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Scheduler
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface ISchedulerManager.
    /// </summary>
    public interface ISchedulerManager
    {
        /// <summary>
        /// Processes the email.
        /// </summary>
        /// <returns>Task.</returns>
        Task<bool> ProcessEmail();
    }
}
