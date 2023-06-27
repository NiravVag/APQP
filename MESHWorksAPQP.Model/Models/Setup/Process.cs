// <copyright file="Process.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Setup
{
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Interface;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class Process.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity{System.Guid}" />
    [Table("Process", Schema = "Setup")]
    public class Process : SetupBaseEntity, ISetupBaseEntity
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