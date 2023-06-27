// <copyright file="Gate.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.APQP.Gates
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Models.APQP.Template;
    using MESHWorksAPQP.Model.Models.APQP.WorkFlow;
    using MESHWorksAPQP.Model.Models.CustomField;

    /// <summary>
    /// class Gate.
    /// </summary>
    [Table("Gate", Schema = "APQP")]
    public class Gate : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gate"/> class.
        /// </summary>
        public Gate()
        {
            this.CustomFieldGateMappings = new HashSet<CustomFieldGateMapping>();
            this.CustomFields = new HashSet<CustomField>();
            this.GateClosureSetiings = new HashSet<GateClosureSetting>();
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
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [MaxLength(50)]
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the apqp template identifier.
        /// </summary>
        /// <value>
        /// The apqp template identifier.
        /// </value>
        public Guid APQPTemplateId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the Always Editable.
        /// </summary>
        /// <value>
        /// The always editable identifier.
        /// </value>
        public bool IsAlwaysEditable { get; set; }

        /// <summary>
        /// Gets or sets the apqp template.
        /// </summary>
        /// <value>
        /// The apqp template.
        /// </value>
        public virtual APQPTemplate APQPTemplate { get; set; }

        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        /// <value>
        /// The custom fields.
        /// </value>
        public virtual ICollection<CustomField> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the custom field gate mappings.
        /// </summary>
        /// <value>
        /// The custom field gate mappings.
        /// </value>
        public virtual ICollection<CustomFieldGateMapping> CustomFieldGateMappings { get; set; }

        /// <summary>
        /// Gets or sets the gate closure setiings.
        /// </summary>
        /// <value>
        /// The gate closure setiings.
        /// </value>
        public virtual ICollection<GateClosureSetting> GateClosureSetiings { get; set; }
    }
}
