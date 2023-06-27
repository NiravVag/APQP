// <copyright file="Commodity.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Setup
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Interface;

    /// <summary>
    /// Class Commodity.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity{System.Guid}" />
    [Table("Commodity", Schema = "Setup")]
    public class Commodity : SetupBaseEntity, ISetupBaseEntity
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }
    }
}
