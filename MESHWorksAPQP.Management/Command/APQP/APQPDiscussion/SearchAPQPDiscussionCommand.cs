// <copyright file="SearchAPQPDiscussionCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.APQP.APQPDiscussion
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.APQP.Discussion;

    /// <summary>
    /// Class SearchAPQPDiscussionCommand.
    /// </summary>
    public class SearchAPQPDiscussionCommand : Page<APQPDiscussionVM>, ISearchCommand<APQPDiscussionListVM, FilterVM>
    {
        /// <summary>
        /// Gets or sets the apqp identifier.
        /// </summary>
        /// <value>
        /// The apqp identifier.
        /// </value>
        public Guid APQPId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public FilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Page<APQPDiscussionListVM> Result { get; set; }
    }
}
