// <copyright file="SearchCompanyUserTypeCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.Role.CompanyUserType
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Company.CompanyUserType;

    /// <summary>
    /// Class SearchCompanyUserTypeCommand.
    /// </summary>
    public class SearchCompanyUserTypeCommand : Page<CompanyUserTypeListVM>, ISearchCommand<CompanyUserTypeListVM, FilterVM>
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>s
        public FilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Page<CompanyUserTypeListVM> Result { get; set; }
    }
}
