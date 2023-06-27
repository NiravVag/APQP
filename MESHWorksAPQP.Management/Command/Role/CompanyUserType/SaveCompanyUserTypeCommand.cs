// <copyright file="SaveCompanyUserTypeCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.Role.CompanyUserType
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.User.CompanyUserType;

    /// <summary>
    /// Class SaveCompanyUserTypeCommand.
    /// </summary>
    public class SaveCompanyUserTypeCommand : ISaveCommand<CompanyUserTypeVM>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the question section.
        /// </summary>
        /// <value>
        /// The question section.
        /// </value>
        public CompanyUserTypeVM Entity { get; set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public CompanyUserTypeVM Result { get; set; }
    }
}
