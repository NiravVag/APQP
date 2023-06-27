// <copyright file="GateClosureCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.APQP.WorkFlow
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow;

    /// <summary>
    /// class SendGateClosureEmailCommand.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.Commands.IGetCommand&lt;MESHWorksAPQP.Management.ViewModel.APQP.WorkFlow.GateClosureSettingVM&gt;" />
    public class GateClosureCommand : IGetCommand<GateClosureSettingVM>
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
        /// Gets or sets the apqp identifier.
        /// </summary>
        /// <value>
        /// The apqp identifier.
        /// </value>
        public Guid APQPId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public GateClosureSettingVM Entity { get; set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public GateClosureSettingVM Result { get; set; }
    }
}
