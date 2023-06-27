// <copyright file="SaveAPQPProjectCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Commands.APQP
{
    using System;
    using MESHWorksAPQP.Repository.CustomModel.APQP;

    /// <summary>
    /// class SaveAPQPProjectCommand.
    /// </summary>
    public class SaveAPQPProjectCommand
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
        public APQPProjectCM Entity { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public APQPProjectCM Result { get; set; }
    }
}
