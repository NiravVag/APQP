// <copyright file="IActivityManager.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Managers.Activity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Activity;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Activity;

    /// <summary>
    /// Interface IActivityManager
    /// </summary>
    public interface IActivityManager
    {
        /// <summary>
        /// Saves the activity.
        /// </summary>
        /// <param name="activityVM">The activity vm.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<ActivityVM> SaveActivity(ActivityVM activityVM);

        /// <summary>
        /// Gets the activity.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Page<ActivityListVM>> GetActivity(GetActivityCommand command);
    }
}
