// <copyright file="MaterialType.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Model.Models.Setup
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MESHWorksAPQP.Model.Abstract;
    using MESHWorksAPQP.Model.Interface;

    /// <summary>
    /// Class MaterialType.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Model.Abstract.BaseEntity{System.Guid}" />
    [Table("Material", Schema = "Setup")]
    public class MaterialType : SetupBaseEntity, ISetupBaseEntity
    {
        /// <summary>
        /// Gets or sets the commodity identifier.
        /// </summary>
        /// <value>
        /// The commodity identifier.
        /// </value>
        public Guid? CommodityId { get; set; }

        /// <summary>
        /// Gets or sets the commodity.
        /// </summary>
        /// <value>
        /// The commodity.
        /// </value>
        public virtual Commodity Commodity { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }
    }
}
