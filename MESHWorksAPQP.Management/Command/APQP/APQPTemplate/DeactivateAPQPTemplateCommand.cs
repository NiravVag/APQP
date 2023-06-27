// <copyright file="DeactivateAPQPTemplateCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.APQP.APQPTemplate
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;

    /// <summary>
    /// Class DeactivateAPQPTemplateCommand.
    /// </summary>
    public class DeactivateAPQPTemplateCommand : ICommandResult<bool>
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DeactivateAPQPTemplateCommand"/> is result.
        /// </summary>
        /// <value>
        ///   <c>true</c> if result; otherwise, <c>false</c>.
        /// </value>
        public bool Result { get; set; }
    }
}
