// <copyright file="EmailTemplate.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Email
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Shared.Enum;
    using MESHWorksAPQP.Model.Models.Setup;

    /// <summary>
    /// Class EmailTemplate.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity{System.Guid}" />
    [Table("EmailTemplate", Schema = "Email")]
    public class EmailTemplate : BaseEntity
    {
        /// <summary>
        /// Gets or sets the email configuration identifier.
        /// </summary>
        /// <value>
        /// The email configuration identifier.
        /// </value>
        public Guid EmailConfigurationId { get; set; }

        /// <summary>
        /// Gets or sets the configuration of the email.
        /// </summary>
        /// <value>
        /// The configuration of the email.
        /// </value>
        public virtual EmailConfiguration EmailConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the template type enum of the email.
        /// </summary>
        /// <value>
        /// The email template type enum.
        /// </value>
        public EmailTemplateType EmailTemplateType { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [MaxLength(30)]
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        [MaxLength(500)]
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        [Required]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the cc.
        /// </summary>
        /// <value>
        /// The cc.
        /// </value>
        [MaxLength(500)]
        public string CC { get; set; }

        /// <summary>
        /// Gets or sets the bcc.
        /// </summary>
        /// <value>
        /// The bcc.
        /// </value>
        [MaxLength(500)]
        public string BCC { get; set; }

        /// <summary>
        /// Gets or sets the email notification identifier.
        /// </summary>
        /// <value>
        /// The email notification identifier.
        /// </value>
        public Guid? EmailNotificationId { get; set; }

        /// <summary>
        /// Gets or sets the email notification.
        /// </summary>
        /// <value>
        /// The email notification.
        /// </value>
        public virtual EmailNotification EmailNotification { get; set; }
    }
}
