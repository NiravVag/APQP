// <copyright file="GetCustomFieldCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>
namespace MESHWorksAPQP.Management.Commands.CustomField
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.CustomField;

    /// <summary>
    /// Class GetCustomFieldCommand.
    /// </summary>
    public class GetCustomFieldCommand : IGetCommand<CustomFieldVM>
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
        public CustomFieldVM Result { get; set; }
    }
}
