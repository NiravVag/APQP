// <copyright file="SaveAPQPDiscussionCommand.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.Command.APQP.APQPDiscussion
{
    using System;
    using MESHWorksAPQP.Management.Interface.Commands;
    using MESHWorksAPQP.Management.ViewModel.APQP.Discussion;

    /// <summary>
    /// class SaveAPQPDiscussionCommand.
    /// </summary>
    public class SaveAPQPDiscussionCommand : ISaveCommand<APQPDiscussionVM>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the apqp identifier.
        /// </summary>
        /// <value>
        /// The apqp identifier.
        /// </value>
        public Guid APQPId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public APQPDiscussionVM Entity { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public APQPDiscussionVM Result { get; set; }
    }
}
