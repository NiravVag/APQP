// <copyright file="GetPartRelationsCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.Part
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Repository.CustomModel.Part;

    /// <summary>
    /// class GetPartRelationaCommand.
    /// </summary>
    public class GetPartRelationsCommand : List<PartRelationsCM>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public IList<PartRelationsCM> Result { get; set; }
    }
}
