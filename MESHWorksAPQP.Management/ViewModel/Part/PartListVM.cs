// <copyright file="PartListVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Part
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// class PartListVM.
    /// </summary>
    public class PartListVM
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

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
        public string CommodityName { get; set; }

        /// <summary>
        /// Gets or sets the process identifier.
        /// </summary>
        /// <value>
        /// The process identifier.
        /// </value>
        public string ProcessName { get; set; }

        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        public string MaterialTypeName { get; set; }

        /// <summary>
        /// Gets or sets the sam.
        /// </summary>
        /// <value>
        /// The sam.
        /// </value>
        [MaxLength(50)]
        public string SAM { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string CreatedBy { get; set; }
    }
}
