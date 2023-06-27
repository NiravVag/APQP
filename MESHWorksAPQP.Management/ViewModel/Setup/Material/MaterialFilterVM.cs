// <copyright file="MaterialFilterVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Setup
{
    using System;

    /// <summary>
    /// Class MaterialFilterVM.
    /// </summary>
    public class MaterialFilterVM : FilterVM
    {
        /// <summary>
        /// Gets or sets the commodity identifier.
        /// </summary>
        /// <value>
        /// The commodity identifier.
        /// </value>
        public Guid? CommodityId { get; set; }

        /// <summary>
        /// Gets or sets the material group identifier.
        /// </summary>
        /// <value>
        /// The material group identifier.
        /// </value>
        public Guid? MaterialGroupId { get; set; }

        /// <summary>
        /// Gets or sets the material group identifier.
        /// </summary>
        /// <value>
        /// The material Id identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }
    }
}
