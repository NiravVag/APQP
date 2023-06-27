// <copyright file="SearchCompanyModuleCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.Role.CompanyModule
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using MESHWorksAPQP.Management.Interface.Commands.Role.CompanyModule;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Repository.CustomModel;

    /// <summary>
    /// Class SearchCompanyModuleCommand.
    /// </summary>
    public class SearchCompanyModuleCommand : List<CompanyModuleDetail>, ISearchCompanyModuleCommand
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
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
