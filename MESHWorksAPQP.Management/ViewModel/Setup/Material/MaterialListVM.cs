// <copyright file="MaterialListVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Setup
{
    using System;
    using MESHWorksAPQP.Shared.Enum;

    /// <summary>
    /// Class MaterialListVM.
    /// </summary>
    public class MaterialListVM : SetupListVM
    {
        /// <summary>
        /// Gets or sets the name of the commodity.
        /// </summary>
        /// <value>
        /// The name of the commodity.
        /// </value>
        public string CommodityName { get; set; }

        /// <summary>
        /// Gets or sets the name of the material group.
        /// </summary>
        /// <value>
        /// The name of the material group.
        /// </value>
        public string MaterialGroupName { get; set; }
    }
}
