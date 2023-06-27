// <copyright file="Activity.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Activity
{
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Shared.Enum;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// class Activity
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity" />
    public class Activity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public Guid EntityId { get; set; }
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public Guid? ReferenceId { get; set; }
        /// <summary>
        /// Gets or sets the child entity identifier.
        /// </summary>
        /// <value>
        /// The child entity identifier.
        /// </value>
        public Guid? ChildEntityId { get; set; }
        /// <summary>
        /// Gets or sets the type of the activity.
        /// </summary>
        /// <value>
        /// The type of the activity.
        /// </value>
        public ActivityType ActivityType { get; set; }
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public string Comment { get; set; }
        /// <summary>
        /// Gets or sets the name of the activity.
        /// </summary>
        /// <value>
        /// The name of the activity.
        /// </value>
        public string ActivityName { get; set; }
    }
}
