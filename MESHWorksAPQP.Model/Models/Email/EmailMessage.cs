// <copyright file="EmailMessage.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Email
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// Class EmailMessage.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity{System.Guid}" />
    [Table("EmailMessage", Schema = "Email")]
    public class EmailMessage : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailMessage"/> class.
        /// </summary>
        public EmailMessage()
        {
            this.EmailAttachments = new HashSet<EmailAttachment>();
        }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets the email template identifier.
        /// </summary>
        /// <value>
        /// The email template identifier.
        /// </value>
        public Guid EmailTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the template of the email.
        /// </summary>
        /// <value>
        /// The email template.
        /// </value>
        public virtual EmailTemplate EmailTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template type enum of the email.
        /// </summary>
        /// <value>
        /// The email template type enum.
        /// </value>
        public EmailTemplateType EmailTemplateType { get; set; }

        /// <summary>
        /// Gets or sets the refrence entity identifier.
        /// </summary>
        /// <value>
        /// The refrence entity identifier.
        /// </value>
        public Guid? ReferenceEntityId { get; set; }

        /// <summary>
        /// Gets or sets the email from.
        /// </summary>
        /// <value>
        /// The email from.
        /// </value>
        [MaxLength(50)]
        [Required]
        public string EmailFrom { get; set; }

        /// <summary>
        /// Gets or sets the to.
        /// </summary>
        /// <value>
        /// The to.
        /// </value>
        [MaxLength(500)]
        [Required]
        public string To { get; set; }

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
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        [MaxLength(300)]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public EmailStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the date sent.
        /// </summary>
        /// <value>
        /// The date sent.
        /// </value>
        public DateTime DateSent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has attachment.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has attachment; otherwise, <c>false</c>.
        /// </value>
        public bool HasAttachment { get; set; }

        /// <summary>
        /// Gets or sets the retry count.
        /// </summary>
        /// <value>
        /// The retry count.
        /// </value>
        public int RetryCount { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the email attachments.
        /// </summary>
        /// <value>
        /// The email attachments.
        /// </value>
        public virtual ICollection<EmailAttachment> EmailAttachments { get; set; }
    }
}
