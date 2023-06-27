// <copyright file="ProcessFilterVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

namespace MESHWorksAPQP.Management.ViewModel.Setup.Process
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// class ProcessFilterVM
    /// </summary>
    /// <seealso cref="MESHWorksAPQP.Management.ViewModel.FilterVM" />
    public class ProcessFilterVM : FilterVM
    {
        /// <summary>
        /// Gets or sets the process identifier.
        /// </summary>
        /// <value>
        /// The process identifier.
        /// </value>
        public Guid? ProcessId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public Guid? CompanyId { get; set; }
    }
}
