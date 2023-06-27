// <copyright file="SearchMaterialTypeCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.Setup.MaterialType
{
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;


    /// <summary>
    /// class SearchProcessCommand.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.ViewModel.Page&lt;MESHWorksAPQP.Management.ViewModel.Setup.SetupListVM&gt;" />
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.ISearchCommand&lt;MESHWorksAPQP.Management.ViewModel.Setup.SetupListVM, MESHWorksAPQP.Management.ViewModel.Setup.MaterialFilterVM&gt;" />
    public class SearchMaterialTypeCommand : Page<SetupListVM>, ISearchCommand<SetupListVM, MaterialFilterVM>
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public MaterialFilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Page<SetupListVM> Result { get; set; }
    }
}
