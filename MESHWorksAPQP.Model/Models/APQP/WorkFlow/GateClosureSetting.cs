// <copyright file="GateClosureSetting.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.APQP.WorkFlow
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Models.APQP.Gates;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// class GateClosureSetting.
    /// </summary>
    [Table("GateClosureSetting", Schema = "APQP")]
    public class GateClosureSetting : BaseEntity
    {
        /// <summary>
        /// Gets or sets the gate identifier.
        /// </summary>
        /// <value>
        /// The gate identifier.
        /// </value>
        public Guid GateId { get; set; }

        /// <summary>
        /// Gets or sets the gate.
        /// </summary>
        /// <value>
        /// The gates.
        /// </value>
        public virtual Gate Gate { get; set; }

        /// <summary>
        /// Gets or sets the type of the clouser.
        /// </summary>
        /// <value>
        /// The type of the clouser.
        /// </value>
        public virtual ClouserType ClouserType { get; set; }
    }
}
