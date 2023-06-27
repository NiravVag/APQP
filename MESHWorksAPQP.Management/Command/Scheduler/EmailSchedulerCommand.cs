// <copyright file="EmailSchedulerCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.Scheduler
{
    using MESHWorksAPQP.Management.Interface.Commands;

    /// <summary>
    /// Class EmailSchedulerCommand.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.ICommandResult{System.Boolean}" />
    public class EmailSchedulerCommand : ICommandResult<bool>
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public bool Result { get; set; }
    }
}
