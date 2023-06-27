// <copyright file="ReOpenGateCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.APQP.WorkFlow
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow;

    /// <summary>
    /// class ReOpenGateCommand.
    /// </summary>
    public class ReOpenGateCommand : IGetCommand<bool>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public ReOpenGateVM Entity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public bool Result { get; set; }
    }
}
