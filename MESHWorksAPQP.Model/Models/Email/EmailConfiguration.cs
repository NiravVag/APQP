// <copyright file="EmailConfiguration.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Email
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;

    /// <summary>
    /// Class EmailConfiguration.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity{System.Guid}" />
    [Table("EmailConfiguration", Schema = "Email")]
    public class EmailConfiguration : BaseEntity
    {
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
        /// Gets or sets the server for this user.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        [MaxLength(100)]
        [Required]
        public string Server { get; set; }

        /// <summary>
        /// Gets or sets the email address for this user.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password for this user.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [MaxLength(30)]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the port for this user.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance use ssl.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has attachment; otherwise, <c>false</c>.
        /// </value>
        public bool UseSSL { get; set; }
    }
}
