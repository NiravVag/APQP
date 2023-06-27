// <copyright file="SearchAPQPDocumentCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.APQP
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Document;
    using MESHWorksAPQP.Repository.CustomModel.APQP;

    /// <summary>
    /// SearchAPQPDocumentCommand
    /// </summary>
    public class SearchAPQPDocumentCommand : Page<APQPPartDocumentCM>, ISearchCommand<APQPPartDocumentCM, PartDocumentFilterVM>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public PartDocumentFilterVM Filter { get; set; }

        /// <summary>
        /// Gets or sets the result
        /// </summary>
        public Page<APQPPartDocumentCM> Result { get; set; }
    }
}
