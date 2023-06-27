// <copyright file="SearchAPQPTemplateCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.Part
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.Document;
    using MESHWorksAPQP.Repository.CustomModel.APQP;

    /// <summary>
    /// class SearchAPQPTemplateCommand.
    /// </summary>
    public class SearchPartDocumentCommand : Page<APQPPartDocumentCM>, ISearchCommand<APQPPartDocumentCM, PartDocumentFilterVM>
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
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Page<APQPPartDocumentCM> Result { get; set; }
    }
}
