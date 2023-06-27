// <copyright file="APQPTemplateVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.APQP
{
    using System;
    using System.Collections.Generic;
    using MESHWorksAPQP.Management.Interface.ViewModel;
    using MESHWorksAPQP.Management.ViewModel.APQP.Gates;

    /// <summary>
    /// class APQPTemplateVM.
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.Interface.ViewModel.ISaveResult" />
    public class APQPTemplateVM : ISaveResult
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
        public Guid? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The apqp description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is system default; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystemDefault { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is apqp exist.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is apqp exist; otherwise, <c>false</c>.
        /// </value>
        public bool IsAPQPExist { get; set; }

        /// <summary>
        /// Gets or sets the gate.
        /// </summary>
        /// <value>
        /// The gate.
        /// </value>
        public List<GateVM> Gates { get; set; }
    }
}
