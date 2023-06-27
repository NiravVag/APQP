// <copyright file="EmailNotificationPreference.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Email
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Models.Setup;

    /// <summary>
    /// Class EmailNotificationPreference.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity" />
    [Table("EmailNotificationPreference", Schema = "Email")]
    public class EmailNotificationPreference : BaseEntity
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="EmailNotificationPreference"/> class.
        /// </summary>
        public EmailNotificationPreference()
        {
            this.EmailNotificationPreferenceUsers = new HashSet<EmailNotificationPreferenceUser>();
        }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the email notification identifier.
        /// </summary>
        /// <value>
        /// The email notification identifier.
        /// </value>
        public Guid EmailNotificationId { get; set; }

        /// <summary>
        /// Gets or sets the email notification.
        /// </summary>
        /// <value>
        /// The email notification.
        /// </value>
        public virtual EmailNotification EmailNotification { get; set; }

        /// <summary>
        /// Gets or sets the email notification preference users.
        /// </summary>
        /// <value>
        /// The email notification preference users.
        /// </value>
        public virtual ICollection<EmailNotificationPreferenceUser> EmailNotificationPreferenceUsers { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is owner.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is owner; otherwise, <c>false</c>.
        /// </value>
        public bool IsOwner { get; set; }
    }
}
