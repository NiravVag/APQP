// <copyright file="SearchPartCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.Part
{
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Part;

    /// <summary>
    /// class SearchPartCommand.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.ViewModel.Page&lt;MESHWorksAPQP.Management.ViewModel.Part.PartListVM&gt;" />
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.ISearchCommand&lt;MESHWorksAPQP.Management.ViewModel.Part.PartListVM, MESHWorksAPQP.Management.ViewModel.Part.PartFilterVM&gt;" />
    public class SearchPartCommand : Page<PartListVM>, ISearchCommand<PartListVM, PartFilterVM>
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public PartFilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Page<PartListVM> Result { get; set; }
    }
}
