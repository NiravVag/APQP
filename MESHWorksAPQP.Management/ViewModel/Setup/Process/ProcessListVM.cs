// <copyright file="ProcessListVM.cs" company="MESHWorksAPQP">
// Copyright (c) MESHWorksAPQP. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace MESHWorksAPQP.Management.ViewModel.Setup.Process
{
    /// <summary>
    /// class ProcessListVM
    /// </summary>
    public class ProcessListVM
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        public Guid Id { get; set; }


        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }


        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the sortorder.
        /// </summary>
        /// <value>
        /// The sortorder.
        /// </value>
        public int SortOrder { get; set; }
    }
}
