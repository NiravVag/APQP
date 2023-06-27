// <copyright file="PartVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Part
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MESHWorksAPQP.Management.Interface.ViewModel;

    /// <summary>
    /// class PartVM.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.ViewModel.ISaveResult" />
    public class PartVM : ISaveResult
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
        public List<Guid> ParentPartId { get; set; }

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
        [MaxLength(50)]
        [Required]
        public string PartNumber { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [MaxLength(300)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the drawing number.
        /// </summary>
        /// <value>
        /// The drawing number.
        /// </value>
        [MaxLength(50)]
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
        public Guid? MaterialTypeId { get; set; }

        /// <summary>
        /// Gets or sets the sam.
        /// </summary>
        /// <value>
        /// The sam.
        /// </value>
        [MaxLength(50)]
        public string SAM { get; set; }

        /// <summary>
        /// Gets or sets the initial rev level.
        /// </summary>
        /// <value>
        /// The initial rev level.
        /// </value>
        [MaxLength(50)]
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
        [MaxLength(50)]
        public string EAU { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        [MaxLength(50)]
        public string Customer { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        [MaxLength(50)]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        /// <value>
        /// The customer email.
        /// </value>
        [MaxLength(100)]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or sets the customer phone.
        /// </summary>
        /// <value>
        /// The customer phone.
        /// </value>
        [MaxLength(50)]
        public string CustomerPhone { get; set; }

        /// <summary>
        /// Gets or sets the name of the other material process.
        /// </summary>
        /// <value>
        /// The name of the other material process.
        /// </value>
        [MaxLength(50)]
        public string OtherProcessName { get; set; }

        /// <summary>
        /// Gets or sets the name of the other material type.
        /// </summary>
        /// <value>
        /// The name of the other material type.
        /// </value>
        [MaxLength(50)]
        public string OtherMaterialTypeName { get; set; }
    }
}
