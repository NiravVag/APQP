// <copyright file="SearchGateCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.APQP
{
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.APQP.Gates;

    /// <summary>
    /// class SearchGateCommand.
    /// </summary>
    public class SearchGateCommand : Page<GateListVM>, ISearchCommand<GateListVM, FilterVM>
    {
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
        public Page<GateListVM> Result { get; set; }
    }
}
