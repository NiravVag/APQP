// <copyright file="SaveCompanyModuleCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.Role.CompanyModule
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.Interface.Commands.Role.CompanyModule;
    using MESHWorksAPQP.Repository.CustomModel;

    /// <summary>
    /// Class SaveCompanyModuleCommand.
    /// </summary>
    public class SaveCompanyModuleCommand : List<CompanyModuleDetail>, ISaveCompanyModuleCommand
    {
        /// <summary>
        /// Gets or sets the question section.
        /// </summary>
        /// <value>
        /// The question section.
        /// </value>
        public List<CompanyModuleDetail> Entity { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public List<CompanyModuleDetail> Result { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }
    }
}
