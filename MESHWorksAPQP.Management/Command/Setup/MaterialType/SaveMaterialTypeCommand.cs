﻿// <copyright file="SaveMaterialTypeCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.Setup.MaterialType
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.Setup;

    /// <summary>
    /// class SavePartCommand.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.ISaveCommand&lt;MESHWorksAPQP.Management.ViewModel.Setup.MaterialVM&gt;" />
    public class SaveMaterialTypeCommand : ISaveCommand<MaterialVM>
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
        public MaterialVM Entity { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public MaterialVM Result { get; set; }
    }
}
