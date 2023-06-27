// <copyright file="SaveDesignationCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.Setup.Designation
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.Setup;

    /// <summary>
    /// class SaveDesignationCommand.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.ISaveCommand&lt;MESHWorksAPQP.Management.ViewModel.Setup.SetupVM&gt;" />
    public class SaveDesignationCommand : ISaveCommand<SetupVM>
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
