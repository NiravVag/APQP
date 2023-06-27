// <copyright file="EmailPlaceHolder.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Email
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// Class EmailPlaceHolder.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity{System.Guid}" />
    [Table("EmailPlaceHolder", Schema = "Email")]
    public class EmailPlaceHolder : BaseEntity
    {
        /// <summary>
        /// Gets or sets the template type enum of the email.
        /// </summary>
        /// <value>
        /// The email template type enum.
        /// </value>
        public EmailTemplateType EmailTemplateType { get; set; }

        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>
        /// The name of the field.
        /// </value>
        [MaxLength(30)]
        [Required]
        public string FieldName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
