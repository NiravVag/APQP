// <copyright file="GetAPQPTemplateCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.APQP.APQPTemplate
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.APQP;

    /// <summary>
    /// Class GetAPQPTemplateCommand.
    /// </summary>
    public class GetAPQPTemplateCommand : IGetCommand<APQPTemplateVM>
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
        public APQPTemplateVM Result { get; set; }
    }
}
