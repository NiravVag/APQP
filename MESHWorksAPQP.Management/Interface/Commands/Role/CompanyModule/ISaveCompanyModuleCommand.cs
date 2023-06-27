// <copyright file="ISaveCompanyModuleCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Commands.Role.CompanyModule
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Repository.CustomModel;

    /// <summary>
    /// Interface ISaveCompanyModuleCommand.
    /// </summary>
    public interface ISaveCompanyModuleCommand
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the question section.
        /// </summary>
        /// <value>
        /// The question section.
        /// </value>
        public List<CompanyModuleDetail> Entity { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public List<CompanyModuleDetail> Result { get; set; }
    }
}