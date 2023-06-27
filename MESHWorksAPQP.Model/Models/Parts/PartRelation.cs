// <copyright file="PartRelation.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Parts
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;

    /// <summary>
    /// class PartRelation.
    /// </summary>
    [Table("PartRelation", Schema = "APQP")]
    public class PartRelation : BaseEntity
    {
        /// <summary>
        /// Gets or sets the parts identifier.
        /// </summary>
        /// <value>
        /// The parts identifier.
        /// </value>
        public Guid PartId { get; set; }

        /// <summary>
        /// Gets or sets the parent part identifier.
        /// </summary>
        /// <value>
        /// The parent part identifier.
        /// </value>
        public Guid ParentPartId { get; set; }

        /// <summary>
        /// Gets or sets the part.
        /// </summary>
        /// <value>
        /// The parts.
        /// </value>
        public virtual Part Part { get; set; }
    }
}
