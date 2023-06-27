// <copyright file="BaseEntity.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MESHWorksAPQP.Model.Interface;

    /// <summary>
    /// Class BaseEntity.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    /// <seealso cref="MESHWorksAPQP.Model.Interface.IBaseEntity{T}" />
    /// <seealso cref="MESHWorksAPQP.Model.Interface.IAuditable" />
    public abstract class BaseEntity : IBaseEntity, IAuditable
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        [Column(Order = 101)]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        [Column(Order = 102)]
        [MaxLength(36)]
        [Required]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        /// <value>
        /// The last modified.
        /// </value>
        [Column(Order = 103)]
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Gets or sets the last modified by.
        /// </summary>
        /// <value>
        /// The last modified by.
        /// </value>
        [Column(Order = 104)]
        [MaxLength(36)]
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        [Column(Order = 105)]
        public bool IsDeleted { get; set; }
    }
}
