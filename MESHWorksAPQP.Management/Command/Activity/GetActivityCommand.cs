// <copyright file="GetActivityCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.Activity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Activity;

    /// <summary>
    /// Class GetActivityCommand
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.IGetCommand&lt;System.Collections.Generic.List&lt;MESHWorksAPQP.Management.ViewModel.Activity.ActivityVM&gt;&gt;" />
    public class GetActivityCommand : ISearchCommand<ActivityListVM, ActivityFilterVM>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public ActivityFilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Page<ActivityListVM> Result { get; set; }
    }
}
