// <copyright file="GetLookupCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.Lookup
{
    using System.Collections.Generic;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.Lookup;

    /// <summary>
    /// Class GetLookupCommand.
    /// </summary>
    public class GetLookupCommand : ICommandResult<List<LookupCollectionVM>>
    {
        /// <summary>
        /// Gets or sets the lookup query.
        /// </summary>
        /// <value>
        /// The lookup query.
        /// </value>
        public List<LookupQuery> Filters { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public List<LookupCollectionVM> Result { get; set; }
    }
}
