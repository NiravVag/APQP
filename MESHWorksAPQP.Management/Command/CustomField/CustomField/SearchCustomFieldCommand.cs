// <copyright file="SearchCustomFieldCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.CustomField
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.CustomField;

    /// <summary>
    /// Class SearchCustomFieldCommand.
    /// </summary>
    public class SearchCustomFieldCommand : Page<CustomFieldListVM>, ISearchCommand<CustomFieldListVM, CustomFieldFilterVM>
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public CustomFieldFilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Page<CustomFieldListVM> Result { get; set; }
    }
}
