// <copyright file="APQP.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.APQP
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Models.APQP.Template;
    using MESHWorksAPQP.Model.Models.Parts;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class APQP.
    /// </summary>
    [Table("APQP", Schema = "APQP")]
    public class APQP : BaseEntity
    {
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
        /// Gets or sets the parts identifier.
        /// </summary>
        /// <value>
        /// The parts identifier.
        /// </value>
        public Guid? PartId { get; set; }

        /// <summary>
        /// Gets or sets the parts.
        /// </summary>
        /// <value>
        /// The parts.
        /// </value>
        public virtual Part Parts { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the apqp template identifier.
        /// </summary>
        /// <value>
        /// The apqp template identifier.
        /// </value>
        public Guid APQPTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the apqp template.
        /// </summary>
        /// <value>
        /// The apqp template.
        /// </value>
        public virtual APQPTemplate APQPTemplate { get; set; }

        /// <summary>
        /// Gets or sets the active gate identifier.
        /// </summary>
        /// <value>
        /// The active gate identifier.
        /// </value>
        public Guid? ActiveGateId { get; set; }

        /// <summary>
        /// Gets or sets the name of the active gate.
        /// </summary>
        /// <value>
        /// The name of the active gate.
        /// </value>
        public string ActiveGateName { get; set; }


        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public APQPStatus Status { get; set; }
    }
}
