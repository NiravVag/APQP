﻿// <copyright file="GateClosureEmail.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.APQP.WorkFlow
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;

    /// <summary>
    /// class GateClosureEmail.
    /// </summary>
    [Table("GateClosureEmail", Schema = "APQP")]
    public class GateClosureEmail : BaseEntity
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
        /// Gets or sets to.
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        [MaxLength(500)]
        public string To { get; set; }

        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        [MaxLength(100)]
        public string From { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        [MaxLength(300)]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the cc.
        /// </summary>
        /// <value>
        /// The cc.
        /// </value>
        [MaxLength(500)]
        public string CC { get; set; }

        /// <summary>
        /// Gets or sets the BCC.
        /// </summary>
        /// <value>
        /// The BCC.
        /// </value>
        [MaxLength(500)]
        public string BCC { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}
