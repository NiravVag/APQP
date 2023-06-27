// <copyright file="MaterialVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Setup
{
    using System;
    using MESHWorksAPQP.Management.Interface.ViewModel;

    /// <summary>
    /// Class MaterialVM.
    /// </summary>
    public class MaterialVM : SetupVM, ISaveResult
    {
        /// <summary>
        /// Gets or sets the commodity identifier.
        /// </summary>
        /// <value>
        /// The commodity identifier.
        /// </value>
        public Guid CommodityId { get; set; }

        /// <summary>
        /// Gets or sets the material group identifier.
        /// </summary>
        /// <value>
        /// The material group identifier.
        /// </value>
        public Guid? MaterialGroupId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has equivalent name.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has equivalent name; otherwise, <c>false</c>.
        /// </value>
        public bool HasEquivalentName { get; set; }

        /// <summary>
        /// Gets or sets the equivalent names.
        /// </summary>
        /// <value>
        /// The equivalent names.
        /// </value>
        public string[] EquivalentNames { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has finished component.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has finished component; otherwise, <c>false</c>.
        /// </value>
        public bool HasFinishedComponent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has bulk.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has bulk; otherwise, <c>false</c>.
        /// </value>
        public bool HasBulk { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has scrap.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has scrap; otherwise, <c>false</c>.
        /// </value>
        public bool HasScrap { get; set; }
    }
}
