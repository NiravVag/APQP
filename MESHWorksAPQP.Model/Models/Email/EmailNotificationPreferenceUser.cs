// <copyright file="EmailNotificationPreferenceUser.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Email
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Models.Setup;

    /// <summary>
    /// Class Notification.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity" />
    [Table("EmailNotificationPreferenceUsers", Schema = "Email")]
    public class EmailNotificationPreferenceUser : BaseEntity
    {
        /// <summary>
        /// Gets or sets the email notification preference identifier.
        /// </summary>
        /// <value>
        /// The email notification preference identifier.
        /// </value>
        public Guid EmailNotificationPreferenceId { get; set; }

        /// <summary>
        /// Gets or sets the email notification preference.
        /// </summary>
        /// <value>
        /// The email notification preference.
        /// </value>
        public virtual EmailNotificationPreference EmailNotificationPreference { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public Guid? RoleId { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public virtual Roles Role { get; set; }
    }
}
