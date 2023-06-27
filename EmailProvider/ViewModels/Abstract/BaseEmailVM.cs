// <copyright file="BaseEmailVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace EmailProvider.ViewModels.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// Class BaseEmailVM.
    /// </summary>
    public abstract class BaseEmailVM
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets the type of the email.
        /// </summary>
        /// <value>
        /// The type of the email.
        /// </value>
        public abstract EmailTemplateType EmailTemplateType { get; }

        /// <summary>
        /// Gets or sets the refrence entity identifier.
        /// </summary>
        /// <value>
        /// The refrence entity identifier.
        /// </value>
        public Guid? ReferenceEntityId { get; set; }

        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        public List<string> To { get; set; }

        /// <summary>
        /// Gets or sets the cc.
        /// </summary>
        /// <value>
        /// The cc.
        /// </value>
        public string CC { get; set; }

        /// <summary>
        /// Gets or sets the bcc.
        /// </summary>
        /// <value>
        /// The bcc.
        /// </value>
        public string BCC { get; set; }

        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
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
        /// Gets or sets the retry count.
        /// </summary>
        /// <value>
        /// The retry count.
        /// </value>
        public int RetryCount { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>
        /// The attachments.
        /// </value>
        public List<EmailAttachmentVM> Attachments { get; set; }
    }
}
