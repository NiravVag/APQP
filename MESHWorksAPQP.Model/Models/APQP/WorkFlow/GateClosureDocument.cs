// <copyright file="GateClosureDocument.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.APQP.WorkFlow
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Models.Setup;

    /// <summary>
    /// class GateClosureDocument.
    /// </summary>
    [Table("GateClosureDocument", Schema = "APQP")]
    public class GateClosureDocument : BaseEntity
    {
        /// <summary>
        /// Gets or sets the gate closure setting identifier.
        /// </summary>
        /// <value>
        /// The gate closure setting identifier.
        /// </value>
        public Guid GateClosureSettingId { get; set; }

        /// <summary>
        /// Gets or sets the gate closure setting.
        /// </summary>
        /// <value>
        /// The gate closure setting.
        /// </value>
        public virtual GateClosureSetting GateClosureSetting { get; set; }

        /// <summary>
        /// Gets or sets the document type identifier.
        /// </summary>
        /// <value>
        /// The document type identifier.
        /// </value>
        public Guid DocumentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the document.
        /// </summary>
        /// <value>
        /// The type of the document.
        /// </value>
        public virtual DocumentType DocumentType { get; set; }
    }
}
