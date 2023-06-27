// <copyright file="GetGroupedLookupCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.Lookup
{
    using System.Collections.Generic;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.Lookup;

    /// <summary>
    /// Class GetGroupedLookupCommand.
    /// </summary>
    public class GetGroupedLookupCommand : ICommandResult<List<GroupedLookupVM>>
    {
        /// <summary>
        /// Gets or sets the lookup query.
        /// </summary>
        /// <value>
        /// The lookup query.
        /// </value>
        public LookupQuery Filters { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public List<GroupedLookupVM> Result { get; set; }
    }
}
