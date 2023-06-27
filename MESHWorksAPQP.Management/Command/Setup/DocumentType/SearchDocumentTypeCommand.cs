// <copyright file="SearchDocumentTypeCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.Setup.DocumentType
{
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Setup;
    using MESHWorksAPQP.Management.ViewModel.Setup.DocumentType;

    /// <summary>
    /// class SearchDocumentTypeCommand.
    /// </summary>
    public class SearchDocumentTypeCommand : Page<SetupListVM>, ISearchCommand<SetupListVM, SetupFilterVM>
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public SetupFilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Page<SetupListVM> Result { get; set; }
    }
}
