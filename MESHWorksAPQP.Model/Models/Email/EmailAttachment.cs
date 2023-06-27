// <copyright file="EmailAttachment.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Email
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;

    /// <summary>
    /// Class EmailAttachment.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity{System.Guid}" />
    [Table("EmailAttachment", Schema = "Email")]
    public class EmailAttachment : BaseEntity
    {
        /// <summary>
        /// Gets or sets the email message identifier.
        /// </summary>
        /// <value>
        /// The email message identifier.
        /// </value>
        public Guid EmailMessageId { get; set; }

        /// <summary>
        /// Gets or sets the email message.
        /// </summary>
        /// <value>
        /// The email message.
        /// </value>
        public virtual EmailMessage EmailMessage { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        [MaxLength(200)]
        [Required]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        [MaxLength(500)]
        [Required]
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        [MaxLength(100)]
        [Required]
        public string ContentType { get; set; }
    }
}
