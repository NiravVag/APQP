// <copyright file="DeleteDocumentTypeCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.Setup.DocumentType
{
    using System;
    using MESHWorksAPQP.Management.Interface.ViewModel;

    /// <summary>
    /// Class DeleteCommodityCommand.
    /// </summary>
    public class DeleteDocumentTypeCommand : IDeleteCommand
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DeleteDocumentTypeCommand"/> is result.
        /// </summary>
        /// <value>
        ///   <c>true</c> if result; otherwise, <c>false</c>.
        /// </value>
        public bool Result { get; set; }
    }
}
