// <copyright file="GetActiveCustomFieldCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>
namespace MESHWorksAPQP.Management.Commands.CustomField
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.CustomField;
    using MESHWorksAPQP.Repository.CustomModel.CustomField;

    /// <summary>
    /// Class GetActiveCustomFieldCommand.
    /// </summary>
    public class GetActiveCustomFieldCommand : ICommandResult<IList<CustomFieldCM>>
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the apqp template identifier.
        /// </summary>
        /// <value>
        /// The apqp template identifier.
        /// </value>
        public Guid? APQPTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public IList<CustomFieldCM> Result { get; set; }
    }
}
