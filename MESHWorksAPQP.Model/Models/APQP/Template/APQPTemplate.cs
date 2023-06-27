// <copyright file="APQPTemplate.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.APQP.Template
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Models.APQP.Gates;

    /// <summary>
    /// class APQPTemplate.
    /// </summary>
    [Table("APQPTemplate", Schema = "APQP")]
    public class APQPTemplate : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APQPTemplate"/> class.
        /// </summary>
        public APQPTemplate()
        {
            this.Gates = new HashSet<Gate>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [MaxLength(300)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is system default; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystemDefault { get; set; }

        /// <summary>
        /// Gets or sets the gates.
        /// </summary>
        /// <value>
        /// The gates.
        /// </value>
        public virtual ICollection<Gate> Gates { get; set; }
    }
}
