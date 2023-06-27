// <copyright file="APQPTemplateValidationCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.APQP.APQPTemplate
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Management.Interface.Commands;

    /// <summary>
    /// Class APQPTemplateValidationCommand.
    /// </summary>
    public class APQPTemplateValidationCommand : ICommandResult<List<string>>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public List<string> Result { get; set; }
    }
}
