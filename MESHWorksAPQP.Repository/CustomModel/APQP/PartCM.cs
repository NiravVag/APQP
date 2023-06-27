// <copyright file="PartCM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Repository.CustomModel.APQP
{
    using System;

    /// <summary>
    /// class PartCM
    /// </summary>
    public class PartCM
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the parent part identifier.
        /// </summary>
        /// <value>
        /// The parent part identifier.
        /// </value>
        public Guid? ParentPartId { get; set; }

        /// <summary>
        /// Gets or sets the parent part number.
        /// </summary>
        /// <value>
        /// The parent part number.
        /// </value>
        public string ParentPartNumber { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the part number.
        /// </summary>
        /// <value>
        /// The part number.
        /// </value>
        public string PartNumber { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the drawing number.
        /// </summary>
        /// <value>
        /// The drawing number.
        /// </value>
        public string DrawingNumber { get; set; }

        /// <summary>
        /// Gets or sets the commodity identifier.
        /// </summary>
        /// <value>
        /// The commodity identifier.
        /// </value>
        public Guid CommodityId { get; set; }

        /// <summary>
        /// Gets or sets the process identifier.
        /// </summary>
        /// <value>
        /// The process identifier.
        /// </value>
        public Guid ProcessId { get; set; }

        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        public Guid MaterialTypeId { get; set; }

        /// <summary>
        /// Gets or sets the sam.
        /// </summary>
        /// <value>
        /// The sam.
        /// </value>
        public string SAM { get; set; }

        /// <summary>
        /// Gets or sets the initial rev level.
        /// </summary>
        /// <value>
        /// The initial rev level.
        /// </value>
        public string InitialRevLevel { get; set; }

        /// <summary>
        /// Gets or sets the initial rev date.
        /// </summary>
        /// <value>
        /// The initial rev date.
        /// </value>
        public DateTime? InitialRevDate { get; set; }

        /// <summary>
        /// Gets or sets the estimated weight.
        /// </summary>
        /// <value>
        /// The estimated weight.
        /// </value>
        public decimal? EstimatedWeight { get; set; }

        /// <summary>
        /// Gets or sets the eau.
        /// </summary>
        /// <value>
        /// The eau.
        /// </value>
        public string EAU { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        public string Customer { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        /// <value>
        /// The customer email.
        /// </value>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or sets the customer phone.
        /// </summary>
        /// <value>
        /// The customer phone.
        /// </value>
        public string CustomerPhone { get; set; }

        /// <summary>
        /// Gets or sets the name of the other material process.
        /// </summary>
        /// <value>
        /// The name of the other material process.
        /// </value>
        public string OtherProcessName { get; set; }

        /// <summary>
        /// Gets or sets the name of the other material type.
        /// </summary>
        /// <value>
        /// The name of the other material type.
        /// </value>
        public string OtherMaterialTypeName { get; set; }
    }
}