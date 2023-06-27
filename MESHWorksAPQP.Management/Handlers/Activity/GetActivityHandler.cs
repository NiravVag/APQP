// <copyright file="GetActivityHandler.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Handlers.Activity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Command.Activity;
    using MESHWorksAPQP.Management.Interface.Handlers;
    using MESHWorksAPQP.Management.Interface.Managers.Activity;

    /// <summary>
    /// Class GetActivityHandler
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Handlers.ICommandHandler&lt;MESHWorksAPQP.Management.ViewModel.Activity.GetActivityHandler&gt;" />
    public class GetActivityHandler : ICommandHandler<GetActivityCommand>
    {
        /// <summary>
        /// The activity manager
        /// </summary>
        private readonly IActivityManager activityManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetActivityHandler"/> class.
        /// </summary>
        /// <param name="activityManager">The activity manager.</param>
        public GetActivityHandler(IActivityManager activityManager)
        {
            this.activityManager = activityManager;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(GetActivityCommand command)
        {
            command.Result = await this.activityManager.GetActivity(command);
        }
    }
}
