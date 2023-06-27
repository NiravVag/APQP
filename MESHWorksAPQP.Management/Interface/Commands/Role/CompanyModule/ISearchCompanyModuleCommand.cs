// <copyright file="ISearchCompanyModuleCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Interface.Commands.Role.CompanyModule
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Repository.CustomModel;

    /// <summary>
    /// Interface ISearchCompanyModuleCommand.
    /// </summary>
    public interface ISearchCompanyModuleCommand
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>s
        public FilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public IList<CompanyModuleDetail> Result { get; set; }
    }
}