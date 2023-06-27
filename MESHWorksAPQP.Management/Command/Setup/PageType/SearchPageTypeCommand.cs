// <copyright file="SearchPageTypeCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>


namespace MESHWorksAPQP.Management.Command.Setup.PageType
{
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Management.ViewModel.Setup.PageType;

    /// <summary>
    /// class SearchPageTypeCommand.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.ViewModel.Page&lt;MESHWorksAPQP.Management.ViewModel.Setup.SetupListVM&gt;" />
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.ISearchCommand&lt;MESHWorksAPQP.Management.ViewModel.Setup.SetupListVM, MESHWorksAPQP.Management.ViewModel.Setup.SetupListVM&gt;" />
    public class SearchPageTypeCommand : Page<SetupListVM>, ISearchCommand<SetupListVM, PageTypeFilterVM>
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public PageTypeFilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Page<SetupListVM> Result { get; set; }
    }
}
