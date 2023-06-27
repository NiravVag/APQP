// <copyright file="SearchAPQPTemplateCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.APQP.APQPTemplate
{
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.APQP;
    using MESHWorksAPQP.Management.ViewModel.APQP.APQPTemplate;

    /// <summary>
    /// class SearchAPQPTemplateCommand.
    /// </summary>
    public class SearchAPQPTemplateCommand : Page<APQPListTemplateVM>, ISearchCommand<APQPTemplateListVM, APQPTemplateFilterVM>
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public APQPTemplateFilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Page<APQPTemplateListVM> Result { get; set; }
    }
}
