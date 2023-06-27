// <copyright file="GetPartRelationCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.Part
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Management.ViewModel.Part;

    /// <summary>
    /// class GetPartRelationCommand.
    /// </summary>
    public class GetPartRelationCommand : List<PartRelationListVM>
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public List<PartRelationListVM> Result { get; set; }
    }
}
