// <copyright file="UpdateActiveGateIdCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.APQP.WorkFlow
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow;

    /// <summary>
    /// class UpdateActiveGateIdCommand.
    /// </summary>
    public class UpdateGateStatusCommand
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the gate identifier.
        /// </summary>
        /// <value>
        /// The gate identifier.
        /// </value>
        public Guid GateId { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public bool Result { get; set; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public APQPVM Entity { get; set; }
    }
}
