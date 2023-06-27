// <copyright file="SaveDocumentTypeCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.Setup.DocumentType
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.Setup;

    /// <summary>
    /// class SaveDocumentTypeCommand.
    /// </summary>
    public class SaveDocumentTypeCommand : ISaveCommand<SetupVM>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public SetupVM Entity { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public SetupVM Result { get; set; }
    }
}
